# Tool
简单实用的工具
## 简介
包括有winform界面nodejs脚本等做的服务端和客户端工具，简单实用，可以用于测试其他项目中的套接字，rest接口，websocket等。
## webserver
release中server_xxx是可执行文件，直接运行，即可监听8081端口，将同级目录下的assets目录作为静态文件根目录。
可修改参数，-port -assets,默认是8081和assets 例如
```
./server_xxxx -port 8082 -assets /var/www/public
```
则是修改端口为8082，目录为`/var/www/public`
