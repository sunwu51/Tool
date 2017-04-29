/**
 * Created by Frank Local on 2017/4/29.
 */
var fs=require('fs');
var express=require('express');
var io=require('socket.io').listen(1223);
io.on('connection',  function(socket){
    socket.emit('event1',{key:"value"})
    socket.on('error', function(err){
        console.log(err);
    });
    socket.on('disconnect',  function(){
    });
    socket.on('myevent',function (data) {
        console.log(data)
    })
});