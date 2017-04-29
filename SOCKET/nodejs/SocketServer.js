/**
 * Created by Frank Local on 2017/4/29.
 */
var net=require('net');
var socketServer=net.createServer();
socketServer.listen(1222);//开始监听

socketServer.on('connection', function (socket) {
    //可以获得客户端ip地址
    let ipaddress=socket.remoteAddress.substr(socket.remoteAddress.lastIndexOf(':')+1);
    console.log(ipaddress,'连上了');

    //数据接收的事件data
    socket.on('data', function (data) {
        console.log(ipaddress,data);
    });
    //发生错误的事件 一般是不正常关闭
    socket.on('error',function(err){
        console.log('连接错误');
    });
    //连接正常关闭事件
    socket.on('close',function () {
        console.log(ipaddress+'下线');
    })
});