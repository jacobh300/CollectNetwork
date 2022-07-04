<?php


    //Server information
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "unitybackend";


    $userID = $_POST["userID"];

    //Create Connection
    $conn = new mysqli($servername, $username, $password, $dbname);
    
    //Check Connection
    if($conn->connect_error){
        die("connection failed: " .$conn->connect_error);
    }

    //echo "Connected Successfully". "<br>";

    $sql = "SELECT itemID FROM useritems WHERE userID = '". $userID . "'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // output data of each row

        $rows = array();
        while($row = $result->fetch_assoc()) {
            $rows[] = $row;
        }

        echo json_encode($rows);

    } else {
        echo "0";
    }

    $conn->close();


?>