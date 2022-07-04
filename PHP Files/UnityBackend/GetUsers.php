<?php


    //Server information
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "unitybackend";



    

    //Create Connection
    $conn = new mysqli($servername, $username, $password, $dbname);
    
    //Check Connection
    if($conn->connect_error){
        die("connection failed: " .$conn->connect_error);
    }

    echo "Connected Successfully". "<br>";

    $sql = "SELECT username, level FROM users";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            echo "username: " . $row["username"]. " - level: " . $row["level"]. "<br>";
        }

    } else {
        echo "0 results";
    }

    $conn->close();


?>