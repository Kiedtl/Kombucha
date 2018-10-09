#[allow(unused_imports)]
extern crate hyper;
//extern crate sha3;

use hyper::rt::{self, Future, Stream};
use hyper::Client;

use std::collections::hash_map::DefaultHasher;
use std::hash::{Hash, Hasher};

//use sha3::{Digest, Sha3_256};
use std::env;
use std::fs;

//const BUFFER_SIZE: usize = 1024;

use std::ffi::OsStr;
use std::fs::File;
use std::io;
use std::io::prelude::*;
use std::io::BufReader;
use std::path::Path;
use std::str;
use std::string::String;

/*

Hungarian Notation for this program



*/

fn main() {
    let args: Vec<String> = env::args().collect();

    // get command line arguments
    let command = &args[1];
    let value = &args[2];

    // check command variable
    if command == "new" {
        commandNew(value.to_string());
    } else if command == "install" {
        commandInstall(value.to_string());
    } else if command == "run" {
        commandRun(value.to_string());
    } else if command == "info" {
        commandInfo(value.to_string());
    } else if command == "update" {
        commandUpdate(value.to_string());
    } else {
        println!("\n");
        println!("\n");
        println!(
            "Kombucha does not recognize the following command: {}",
            command
        );
    }
}

fn commandNew(secondArg: String) {
    // Get private-culture file to parse it
    let secondArg = String::from(secondArg);
    println!("\n");
    //let privateCulturePath = secondArg.push_str("/privateCulture.txt");

    // Open file
    let mut cultureFile =
        std::fs::File::open(secondArg).expect("privateCulture file not found in given directory");

    // Get all lines into an array
    let cultureFile = BufReader::new(cultureFile);
    let mut cultureData = [
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
        "".to_string(),
    ];
    let mut i = 0;
    println!("Reading data from culture file.");
    println!("Reading raw unprocessed data from culture file.");
    println!("\n");

    for line in cultureFile.lines() {
        let mut iproc = line.unwrap();
        cultureData[i] = iproc;
        println!("{}, {}", cultureData[i], i);
        i = i + 1;

        if i == 10 {
            break;
        }
    }

    // culturefiledata
    let parsedCultureDataemail: Vec<&str> = cultureData[0].split("::").collect();
    let parsedCultureDatapasswd: Vec<&str> = cultureData[1].split("::").collect();
    let parsedCultureDataproductName: Vec<&str> = cultureData[2].split("::").collect();
    let parsedCultureDatalatestVersion: Vec<&str> = cultureData[3].split("::").collect();
    let parsedCultureDatainstallDir: Vec<&str> = cultureData[4].split("::").collect();
    let parsedCultureDataserverDir: Vec<&str> = cultureData[5].split("::").collect();
    let parsedCultureDatapubCultureHref: Vec<&str> = cultureData[6].split("::").collect();
    let parsedCultureDatafileType: Vec<&str> = cultureData[7].split("::").collect();
    let parsedCultureDatadescription: Vec<&str> = cultureData[8].split("::").collect();

    println!("\n\n\n\n\n\nIs this data correct? \n (Y/N) \n");
    println!("Account email address : {}", parsedCultureDataemail[1]);
    println!(
        "Product / Package name : {}",
        parsedCultureDataproductName[1]
    );
    println!(
        "Latest version number : {}",
        parsedCultureDatalatestVersion[1]
    );
    println!(
        "Installation directory : {}",
        parsedCultureDatainstallDir[1]
    );
    println!(
        "Server package file Href : {}",
        parsedCultureDataserverDir[1]
    );
    println!(
        "Public Culture href : {}",
        parsedCultureDatapubCultureHref[1]
    );
    println!("Package file type : {}", parsedCultureDatafileType[1]);
    println!("Description : {}", parsedCultureDatadescription[1]);

    let mut confirmation = String::new();
    println!("\n");

    io::stdin().read_line(&mut confirmation);

    if confirmation == "y" {
        println!("\n\nTo confirm, enter the password specified in privateCulture.txt");
        let mut confirmPass = String::new();
        io::stdin().read_line(&mut confirmPass);
        if confirmPass == parsedCultureDatapasswd[1] {
            continueCommandNew(
                parsedCultureDataemail[1],
                parsedCultureDatapasswd[1],
                parsedCultureDataproductName[1],
                parsedCultureDatalatestVersion[1],
                parsedCultureDatainstallDir[1],
                parsedCultureDataserverDir[1],
                parsedCultureDatapubCultureHref[1],
                parsedCultureDatafileType[1],
                parsedCultureDatadescription[1],
            );
        } else {
            println!("Incorrect password. Aborting.");
        }
    } else if confirmation == "Y" {

    } else if confirmation == "n" {
        println!("Operation canceled by user. Aborting.");
    } else if confirmation == "N" {
        println!("Operation canceled by user. Aborting.");
    } else {
        println!("Invalid input. Aborting.");
    }
}

fn commandInstall(secondArg: String) {}
fn commandRun(secondArg: String) {}
fn commandInfo(secondArg: String) {}
fn commandUpdate(secondArg: String) {}

fn continueCommandNew(
    email: &str,
    passwd: &str,
    name: &str,
    version: &str,
    installdir: &str,
    serverdir: &str,
    publicculturehref: &str,
    filetype: &str,
    description: &str,
) {
    // send request to server
    let client = Client::new();

    ////write password to file
    //let pssdir = "C://Users/Public/Kombucha/temp/kpm.sys";
    //let mut pssfile = File::create(pssdir);
    //pssfile.write_all(passwd);
    let vecpasswd: Vec<char> = &calculate_hash(passwd);
    let hashedpasswd: String = vecpasswd.into_iter().collect(); //hashFunction::<Sha3_256, _>(&mut pssfile, "-");
                                                                //fs::remove_file(pssfile);

    let url: String = "http://kombucha-internal.000webhostapp.com/add.php?email=".to_owned()
        + email
        + "&passwd="
        + &hashedpasswd
        + "&name="
        + name
        + "&version="
        + version
        + "&installdir="
        + installdir
        + "&serverdir="
        + serverdir
        + "&publicculturehref="
        + publicculturehref
        + "&filetype="
        + filetype
        + "&updatemethod="
        + description;

    let uri = url.parse().unwrap();

    client
        .get(uri)
        .map(|res| {
            println!("Response: {}", res.status());
        }).map_err(|err| {
            println!("Error: {}", err);
        });
    println!("\n\n");
}

///// Compute digest value for given `Reader` and print it
///// On any error simply return without doing anything
//fn hashFunction<D: Digest + Default, R: Read>(reader: &mut R, name: &str) -> String {
//    let mut sh = D::default();
//    let mut buffer = [0u8; BUFFER_SIZE];
//    loop {
//        let n = match reader.read(&mut buffer) {
//            Ok(n) => n,
//            Err(_) => return "E0???".to_string(),
//        };
//        sh.input(&buffer[..n]);
//        if n == 0 || n < BUFFER_SIZE {
//            break;
//        }
//    }
//    //print_result(&sh.result(), name);
//    return sh.result();
//}

fn calculate_hash<T: Hash>(t: &T) -> Vec<char> {
    let mut s = DefaultHasher::new();
    t.hash(&mut s);
    let strReturnval: &str = &s.finish().to_string();
    let char_vec: Vec<char> = strReturnval.chars().collect();
    return char_vec;
}
