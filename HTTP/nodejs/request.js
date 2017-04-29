/**
 * Created by Frank Local on 2017/4/29.
 */
//需要的模块
var request = require('request');

var url='http://localhost:8081';
var postdata={key:'value'};

request.post({url:'http://localhost:8081', form:postdata}, function(error, response, body) {
    if (!error && response.statusCode == 200) {
        console.log(body)
    }
});
