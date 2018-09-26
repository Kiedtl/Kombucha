<?php
$servername = "localhost";
$username = "id7211538_root";
$password = "bda2kj4iy";

// Create connection
$conn = new mysqli($servername, $username, $password);

// Check connection
if ($conn->connect_error) {
    die("Error K0001: Database Not Found:" . $conn->connect_error);
} 
//echo "Connected successfully";
$author = $_POST["author"];
$author = $_POST["homepage"];
$author = $_POST["culture"];
$package_name = $_POST["name"];
$email = $_POST["email"];

$sql = "INSERT INTO packages (author, email, package-name, culture, homepage, repo)
VALUES (, 'Doe', 'john@example.com')";

if ($conn->query($sql) === TRUE) {
    echo "Success! New package created.";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}


/*CREATE TABLE `id7211538_kombuchadatabase`.`packages` ( `ID` INT NOT NULL , `author` VARCHAR(200) NOT NULL , `email` VARCHAR(200) NOT NULL , `package-name` VARCHAR(100) NOT NULL , `culture` VARCHAR(256) NOT NULL , `homepage` VARCHAR(256) NULL , `rating` INT(15) NULL DEFAULT '0' , `flags` INT(5) NULL DEFAULT '0' , `repo` VARCHAR(256) NULL , `unknown` INT(255) NOT NULL , PRIMARY KEY (`ID`), UNIQUE `package-name` (`package-name`)) ENGINE = InnoDB;*/


?>