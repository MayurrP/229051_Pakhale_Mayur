const express = require("express");
const app = express();
const mysql = require("mysql");
const cors = require("cors");

app.use(cors());
app.use(express.json());

const db = mysql.createConnection({
    user:'root',
    host:'localhost',
    password:'root123',
    database:'studentrecord'  
});

app.post("/create", (req, res) => {
    const rollno = req.body.rollno;
    const fname = req.body.fname;
    const lname = req.body.lname;
    console.log(rollno+"========"+fname+"========"+lname);

    db.query('INSERT INTO studentinfo(rollno,fname,lname) VALUES(?,?,?)', [rollno,fname,lname],
    (err,result)=>{
        if(err){
            console.log(err);
        }
        else{
            res.send("Value Inserted.");
        }
    }); 
});



app.listen(4000, () => {
  console.log("Yey, your server is running on port 4000");
});
