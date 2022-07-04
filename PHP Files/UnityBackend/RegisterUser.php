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

    echo "Connected Successfully". "<br>";

    $sql = "SELECT username FROM users WHERE username = '". $loginUser . "'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        //Tell user that name is already taken
        echo "Username is taken";
    } else {     
        echo "Creating user...";
        //Insert the user and password into the database
        $sql = "INSERT INTO users (username, password) VALUES ('" .$loginUser . "', '". $loginPass . "')";

        
        if (mysqli_query($conn, $sql)) {
            echo "New record created successfully";
        } else {
            echo "Error: " . $sql . "<br>" . mysqli_error($conn);
        }

    }

    $conn->close();


?>