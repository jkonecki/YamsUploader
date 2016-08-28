using PowerArgs;

namespace DeployRunner
{
    public class DeployArgs
    {
        [ArgRequired]
        public string YamsStorage { get; set; }
        [ArgRequired]
        public string ClusterId { get; set; }
        [ArgRequired]
        public string BinariesPath { get; set; }
        [ArgRequired]
        public string AppVersion { get; set; }
        [ArgRequired]
        public string AppId { get; set; }
    }
}