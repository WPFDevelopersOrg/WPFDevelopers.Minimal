<div align="center"><img src="https://github.com/WPFDevelopersOrg/WPFDevelopers.Minimal/raw/main/src/WPFDevelopers.Minimal/WPFDevelopers.Minimal.Sample.Net40/Resources/WPFDevelopers.Minimal.png"/></div>  

##  Welcome to WPFDevelopers.Minimal  

![.net >= 4.0](https://img.shields.io/badge/.net-%3E%3D4.0-blue) ![Visual Studio 2019](https://img.shields.io/badge/Visual%20Studio%20-2019-blueviolet) 
<a href="https://www.nuget.org/packages/WPFDevelopers.Minimal/">
        <img alt="nuget-version" src="https://img.shields.io/nuget/v/WPFDevelopers.Minimal.svg"></img>
    </a>  <a target="_blank" href="https://qm.qq.com/cgi-bin/qm/qr?k=B61RFy2vvpaKLEDxaW6NsDpPZA-eSyFh&jump_from=webapi"><img border="0" src="https://pub.idqqimg.com/wpa/images/group.png" alt="WPF开发者" title="WPF开发者"></a>   

### [自定义高级控件](https://github.com/WPFDevelopersOrg/WPFDevelopers) https://github.com/WPFDevelopersOrg/WPFDevelopers  

### [码云](https://gitee.com/WPFDevelopersOrg) https://gitee.com/WPFDevelopersOrg  


### 欢迎关注微信公众号  

<img src="https://gitee.com/WPFDevelopersOrg/ResourcesCache/raw/main/resources/wxgzh.jpg"/>  

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

[如何使用Window](#Window窗体) 




###  效果展示  

![0](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/0.png)  


### <a id="Window窗体">Window窗体</a>

XAML  
``` XML
ws:Window x:Class="WpfApp.MainWindow"
```
去除.cs文件中的继承  
``` C#
public partial class MainWindow 
```

![1](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/1.png)  
![2](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/2.png)  
![3](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/3.png)  
![4](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/4.png)  
![5](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/5.png)  
![6](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/6.png)  
![7](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/7.png)  
![8](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/8.png)  
![9](https://raw.githubusercontent.com/WPFDevelopersOrg/ResourcesCache/main/resources/WPFDevelopers.Minimal/9.png)  

