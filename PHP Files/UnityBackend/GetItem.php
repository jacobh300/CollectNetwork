<?php


    //Server information
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "unitybackend";


    //$loginUser = $_POST["loginUser"];
    //$loginPass = $_POST["loginPass"];

    $itemID = $_POST["itemID"];
    //$itemID = 1;


    //Create Connection
    $conn = new mysqli($servername, $username, $password, $dbname);
    
    //Check Connection
    if($conn->connect_error){
        die("connection failed: " .$conn->connect_error);
    }

    //echo "Connected Successfully". "<br>";

    $sql = "SELECT name, description FROM items WHERE id = '". $itemID . "'";
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