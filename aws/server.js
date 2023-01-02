var express = require("express");

var app = express();
var bodyparser = require("body-parser");

app.use(bodyparser.urlencoded({extended:false}));

app.get("/",(req,resp)=>{
    resp.sendFile("/public/index.html",{root:__dirname});
});

app.listen(4000,function(){
    console.log("server on 4000");
});