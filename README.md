<div align="center"><img src="https://github.com/WPFDevelopersOrg/WPFDevelopers.Minimal/raw/main/src/WPFDevelopers.Minimal/WPFDevelopers.Minimal.Sample.Net40/Resources/WPFDevelopers.Minimal.png"/></div>    

##  Welcome to WPFDevelopers.Minimal  

![.net >= 4.0](https://img.shields.io/badge/.net-%3E%3D4.0-blue) ![Visual Studio 2019](https://img.shields.io/badge/Visual%20Studio%20-2019-blueviolet) <a target="_blank" href="https://qm.qq.com/cgi-bin/qm/qr?k=B61RFy2vvpaKLEDxaW6NsDpPZA-eSyFh&jump_from=webapi"><img border="0" src="https://pub.idqqimg.com/wpa/images/group.png" alt="WPF开发者" title="WPF开发者"></a> 



第一步: 添加 nuget;

```
Install-Package WPFDevelopers.Minimal
```


第二步：  App.xaml中增加节点：
``` XML
           <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WPFDevelopers.Minimal;component/Themes/Theme.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```

第三步：添加命名空间：

`xmlns:ws="https://github.com/WPFDevelopersOrg.WPFDevelopers.Minimal"`
