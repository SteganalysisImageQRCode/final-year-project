# Steganalysis of Images using QRC
The steganalysis application deals with the concept of combining cryptography & Steganography.Steganalysis is an efficient technique used to encrypt any form of data and hide the key behind an image or any other digital media to make them more secure. 
It can be used to carry out hidden exchanges and hence can enhance individual privacy. 
The security of Steganalysis can be improved by using Quick Response Code to make it more user-friendly.

# Problem Statement:
The problem statement defines how can we send the message secretly to the destination.<br>
This provides the solution for the security enhancement & secure communication of information between the sneder and receiver.<br>
The data in any form of file can be encrypted and the key of the encryption can be hidden behind the image.<br>
The proposed sytem provides enhanced security by implementing the usage of QR code.

# advantages:
This application can enhance the security and improve privacy.
Due to the usage of Complex algorithms this is difficult to attacks.
It is not vulnerable to threats and attacks.

# Proposed system:
The steganalysis technique can be implemented to encrypt any form of file and hide its key behind an image.it uses AES encryption.
 This image can be converted to QRCode which can be decrypted by any user-friendly device like desktop, Mobile, scanners etc..,
It can support on any operating system  like Windows, MacOS, blackberry, android etc.,

# Future Enhancements:
The future enhancement in the further proposed system is that the software can improve the security for the files that are shared via cloud. It can make use of the database such that it can promote multiple senders and receivers. The filename and also the password can be stored separately in the database. This analysis using QRC can be applied in transmission of big data to overcome the shortfalls of digital media and its associated security techniques. It can be used in cloud data sharing to securely share information.

# Technology 
C#.NET

# Input
•	The input will be the files which the user desires to encrypt & the image behind which the files are to be encrypted.<br>
•	The password consisting of 8 characters must be given as a key to perform encryption.<br>
•	The generated QR must be saved in the form of a png image.<br>

# Output
•	The output will be the QR Code which consists of the encrypted image (with file) and the URL behind it.<br>
•	This QR code can be scanned to view the URL of the image & the URL can be redirected to the original image.<br>
•	The decryption can be carried out by specifying the path of the encrypted file and the QR (png).<br>

# Process Involved : Encryption & QR Generation
1.	The steganalysis application is opened.
2.	The admin alone can login by specifying the username and password.
3.	On the top left corner the admin can select the “encryption” option.
4.	The path of the file to be encrypted is specified in the “input file” text box.
5.	The image behind which the key of the encrypted file is to be hidden is given by clicking the “select image” button.
6.	The key consisting of 8 characters is specified in the form of password.
7.	The “output location” textbox specifies the location of the file.
8.	The “encryption” button is clicked to encrypt the file.
9.	On clicking the button the QR is automatically generated for the specified image.
10.	It prompts the user to save the QR image in png format with any name.
11.	The above QR can be scanned to view the link of the encrypted image.

# Process : Decryption

1.	The decryption can be done only with the encrypted form of the file.
2.	The path of the encrypted file is specified in the “input file” text box.
3.	The QR which is already saved during the encryption is inserted by clicking the “open image” button.
4.	The URL contained by the QR can be retrieved by clicking the “get URL” button.
5.	The retrieved URL will be automatically generated in the “Image URL” text box.
6.	The “Get Image from URL” button can be clicked to view the original image.
7.	The “decryption” button is then clicked to decrypt the original file.

# Task splitup & Module splitup
* **Module 1:**<br>
1.GUI Creation<br>
2.Encryption<br>
The user interface forms are crated using the .net framework for login and encryption. The user can login by providing the credentials.
Then the encryption form is opened where the file & image to encrypt are selected by the user.<br>
* **Module 2:**<br>
1.Hiding key behind image<br>
2.Encrypted Image to QR<br>
Advanced Encryption Standard algorithm (Rijndael Algorithm) has been used for encryption.The steganographyHelper function is used to perform steganography which is used to hide key of the encrypted file.The QR package can be imported to convert the encrypted image to a QR.<br>
* **Module 3:**<br>
1.QR to encrypted Image<br>
2.Extract key from image<br>
The QR containing the URL of the encrypted image can be scanned to retrieve back the URL. The URL is retrieved from image by using get_url_from_qr() function. The image is extracted from URL.<br>
* **Module 4:**<br>
1.Decryption<br>
 The decryption is done by clicking the "Decryption" button. The Rijndael Algorithm can be used for retrieving the original file back.

# team members :
Bhavadharini.K , Meganisha.B

# Project completion status: 
98%
