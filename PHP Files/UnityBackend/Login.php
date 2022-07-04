<?php


    //Server information
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "unitybackend";


    $loginUser = $_POST["loginUser"];
    $loginPass = $_POST["loginPass"];

    //Create Connection
    $conn = new mysqli($servername, $username, $password, $dbname);
    
    //Check Connection
    if($conn->connect_error){
        die("connection failed: " .$conn->connect_error);
    }

    //echo "Connected Successfully". "<br>";

    $sql = "SELECT password, id FROM users WHERE username = '". $loginUser . "'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            if($row["password"] == $loginPass){
                echo $row["id"];
            }else{
                echo "failed";
            }
        }

    } else {
        echo "failed";
    }

    $conn->close();


?>