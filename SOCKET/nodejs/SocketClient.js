/**
 * Created by Frank Local on 2017/4/29.
 */
var net = require('net') ;
var client = net.connect({host:"127.0.0.1",port:1222},function(){
    //这里是连接成功后的回调函数
    client.write(new Buffer([0x01,0x02]));
    //client.write("hello");
});
//data事件是收到数据后的回调函数
client.on("data", function(data) {
    console.log(data) ;
});




