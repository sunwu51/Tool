<?php
/**
 * Created by PhpStorm.
 * User: Frank Local
 * Date: 2017/4/29
 * Time: 17:08
 */
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers:X-Requested-With");
header("Access-Control-Allow-Methods:PUT,POST,GET,DELETE,OPTIONS");
header("X-Powered-By:3.2.1");
header("Content-Type:application/json;charset=utf-8");
exit(json_encode($_POST));