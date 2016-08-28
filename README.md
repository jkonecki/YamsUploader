# YamsUploader
Uploads folder to Yams cluster. To be used with Octopus deploy

#Usage example

```
DeployRunner.exe -YamsStorage UseDevelopmentStorage=true `
>> -ClusterId testcluster `
>> -BinariesPath "c:\users\admin\Documents\Visual Studio 2015\Projects\DeployRunner\bin\debug" `
>> -AppVersion "0.0.1" `
>> -AppId testapp
```

output:

```
Uploading binaries from: "c:\users\admin\Documents\Visual Studio 2015\Projects\DeployRunner\bin\debug", to Id: testapp, Version: 0.0.1
Binaries uploaded
Current DeploymentConfig.json is:
{
  "Applications": []
}
Writing new config:
{
  "Applications": [
    {
      "Id": "testapp",
      "Version": "0.0.1",
      "DeploymentIds": [
        "testcluster"
      ]
    }
  ]
}
DeploymentConfig uploaded
```
