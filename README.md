RedisManage 项目说明
一、项目简介
•	背景: 由于 RedisDesktopManager 在服务器环境下无法正常使用，因此开发了这个基于 .Net6 的 Winform 应用程序作为替代方案。
•	功能: 提供了一个图形用户界面来管理 Redis 数据库。
•	配置: Redis 连接信息可以在 App.config 文件中进行设置和修改。
二、安装依赖包
•	StackExchange.Redis v2.7.33: 用于与 Redis 数据库交互的客户端库。
•	Newtonsoft.Json v13.0.3: 提供 JSON 序列化和反序列化功能。
三、项目运行
•	启动方式: 可以按照常规 Winform 应用程序的方式启动此项目。具体步骤包括但不限于:
•	打开 Visual Studio 或其他支持 .Net6 的 IDE。
•	加载解决方案文件（.sln）。
•	确保项目设置正确（如目标框架为 .Net6）。
•	直接运行或调试应用程序。

欢迎贡献！请遵循以下步骤：
1.	叉取(Fork)此仓库
2.	创建一个新分支 (git checkout -b feature-name)
3.	提交更改 (git commit -m 'Add some feature')
4.	推送到叉取的仓库 (git push origin feature-name)
5.	创建一个新的Pull Request
