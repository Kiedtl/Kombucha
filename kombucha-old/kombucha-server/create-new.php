<?php
$servername = "servrnme";
$username = "usrnme";
$password = "********";

// Create connection
$conn = new mysqli($servername, $username, $password);

// Check connection
if ($conn->connect_error) {
    die("Error K0001: Database Not Found:" . $conn->connect_error);
} 
//echo "Connected successfully";
$author = mysql_real_escape_string($_GET["author"]);
$homepage =  mysql_real_escape_string($_GET["homepage"]);
$culture =  mysql_real_escape_string($_GET["culture"]);
$package_name =  mysql_real_escape_string($_GET["name"]);
$email =  mysql_real_escape_string($_GET["email"]);
$repo =  mysql_real_escape_string($_GET["repo"]);

$sql = "INSERT INTO packages (author, email, package-name, culture, homepage, repo)
VALUES ($author, $email, $package_name, $culture, $homepage, $repo)";

if ($conn->query($sql) === TRUE) {
    echo "Success! New package $package_name created.";
} else {
    echo "Error K0002: " . $sql . "<br>" . $conn->error . ". || Please report this error.";
}


/*CREATE TABLE `id7211538_kombuchadatabase`.`packages` ( `ID` INT NOT NULL , `author` VARCHAR(200) NOT NULL , `email` VARCHAR(200) NOT NULL , `package-name` VARCHAR(100) NOT NULL , `culture` VARCHAR(256) NOT NULL , `homepage` VARCHAR(256) NULL , `rating` INT(15) NULL DEFAULT '0' , `flags` INT(5) NULL DEFAULT '0' , `repo` VARCHAR(256) NULL , `unknown` INT(255) NOT NULL , PRIMARY KEY (`ID`), UNIQUE `package-name` (`package-name`)) ENGINE = InnoDB;*/


?>