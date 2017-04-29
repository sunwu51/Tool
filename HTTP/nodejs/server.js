/**
 * Created by Frank Local on 2017/4/29.
 */
//两个依赖
var express=require('express');
var bodyParser=require('body-parser');

var app=express();
//支持跨域请求
app.all('*', function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "X-Requested-With,wechat");
    res.header("Access-Control-Allow-Methods","PUT,POST,GET,DELETE,OPTIONS");
    res.header("X-Powered-By",' 3.2.1');
    res.header("Content-Type", "application/json;charset=utf-8");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));

//收到什么就返回什么
app.post('/',function (req,res) {
    console.log(req.body);
    res.json(req.body);

});
app.listen(8081);