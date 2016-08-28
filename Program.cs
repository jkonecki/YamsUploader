using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etg.Yams.Application;
using Etg.Yams.Azure.Storage;
using Etg.Yams.Storage;
using PowerArgs;

namespace DeployRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            DeployArgs parsedArgs;
            try
            {
                parsedArgs = Args.Parse<DeployArgs>(args);
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<DeployArgs>());
                throw;
            }

            Run(parsedArgs).Wait();
        }

        private static async Task Run(DeployArgs parsedArgs)
        {
            var deploymentRepository = new BlobStorageDeploymentRepository(parsedArgs.YamsStorage);
            var appIdentity = new AppIdentity(parsedArgs.AppId, parsedArgs.AppVersion);

            Console.WriteLine("Uploading binaries from: \"{0}\", to {1}", parsedArgs.BinariesPath,appIdentity);

            await deploymentRepository.UploadApplicationBinaries(appIdentity, parsedArgs.BinariesPath,  ConflictResolutionMode.FailIfBinariesExist);
            Console.WriteLine("Binaries uploaded");

            var config = await deploymentRepository.FetchDeploymentConfig();
            Console.WriteLine("Current DeploymentConfig.json is:\n\r{0}", config.RawData());

            if (config.HasApplication(parsedArgs.AppId))
            {
                config = config.RemoveApplication(parsedArgs.AppId);
            }
            config = config.AddApplication(appIdentity, parsedArgs.ClusterId);
            Console.WriteLine("Writing new config:\n\r{0}", config.RawData());
            await deploymentRepository.PublishDeploymentConfig(config);
            Console.WriteLine("DeploymentConfig uploaded");
        }
    }
}
