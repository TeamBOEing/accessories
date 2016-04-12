/*
 * BOEbot Test Suite
 * Author: Corbin Murrow
 * Date: 11 April 2016
 * Version: 1.0
 * 
 * This software tests all subsystems of the ESA robot. 
 * 
 * ======= VERSION HISTORY =======
 * Version 1.0: Created and added header, wrote code - CM - 11 April 2016
 */


#include <BOEbot.h>
#include <Servo.h>

void setup() 
{
  initialize();
  Serial.println("Welcome to the BOEbot Test Suite!");
  Serial.println("Use the menu below to select the test you'd like to run.\n");
}

void loop() 
{
  // put your main code here, to run repeatedly:

  printMenu();
  while (Serial.available() == 0) {} // Wait for input
  processInput(Serial.read());
  clearSerial();
}

void printMenu()
{
  Serial.println("1) Motor Test");
  Serial.println("2) IR Test");
  Serial.println("3) LDR Test");
  Serial.println("4) LED Test");
  Serial.println("5) Speaker Test");
}

void processInput(int choice)
{
  switch(choice)
  {
    case 1: performMotorTest(); break;
    case 2: performIRTest(); break;
    case 3: performLDRTest(); break;
    case 4: performLEDTest(); break;
    case 5: performSpeakerTest(); break;
    default: break;
  }
}

void performMotorTest()
{
  clearSerial();
  Serial.println("Welcome to the Motor Test. Send 'c' to exit.\n");

  int shortDelay = 100; //let motors stop spinning before sending new commands
  int longDelay = 1000; //how long any given motor rotation should be
  int pauseDelay = 3000;//definite pause between sections of motor test
  int speed = 200;

  //Left Forward
  Serial.println("Left Forward");
  turnLeftMotorForward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  //Left Backward
  Serial.println("Left Backward");
  turnLeftMotorBackward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  //Right Forward
  Serial.println("Right Forward");
  turnRightMotorForward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  //Right Backward
  Serial.println("Right Backward");
  turnRightMotorBackward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  Serial.println("Individual directions tested, pausing.");
  delay(pauseDelay);
  Serial.println("Begin simultaneous operaton test.");

  //both forward
  Serial.println("Both Forward");
  turnRightMotorForward(speed);
  turnLeftMotorForward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  //both backward
  Serial.println("Both Backward");
  turnRightMotorBackward(speed);
  turnLeftMotorBackward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  //left forward right backward
  Serial.println("Left Forward/Right Backward");
  turnRightMotorBackward(speed);
  turnLeftMotorForward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();
  
  //right forward left backard
  Serial.println("Right Forward/Left Backward");
  turnRightMotorForward(speed);
  turnLeftMotorBackward(speed);
  delay(longDelay); // let run for a moment
  Serial.println("Stop");
  stopLeftMotor();
  stopRightMotor();
  delay(shortDelay);

  Serial.println();

  Serial.println("Simultaneous operation test complete, pausing.");
  delay(pauseDelay);
  Serial.println("Begin motor operation interference test.");

  //start both forward
  Serial.println("Start Both Forward");
  turnRightMotorForward(speed);
  turnLeftMotorForward(speed);
  delay(longDelay);

  //reverse left and return
  Serial.println("Reverse Left");
  stopLeftMotor();
  delay(shortDelay);
  turnLeftMotorBackward(speed);
  delay(longDelay);
  stopLeftMotor();
  delay(shortDelay);
  turnLeftMotorForward(speed);
  
  delay(pauseDelay);
  
  //reverse right and return
  Serial.println("Reverse Right");
  stopRightMotor();
  delay(shortDelay);
  turnRightMotorBackward(speed);
  delay(longDelay);
  stopRightMotor();
  delay(shortDelay);
  turnRightMotorForward(speed);

  delay(pauseDelay);

  Serial.println("Stop All. Motor test complete.");
  stopLeftMotor();
  stopRightMotor();
}

void performIRTest()
{
  clearSerial();
  Serial.println("Welcome to the IR Test. Send 'c' to exit.\n");

  while(Serial.available() == 0)
  {
    Serial.print("Left IR: ");
    // If IR sensor detects object, the return will be HIGH
    if ( leftObstacle() ) {
      turnOnGreenLED();      // Turn green LED on if detected
      Serial.print("1");
    }
    else {
      turnOffGreenLED();      // Turn green LED off if not detected
      Serial.print("0");
    }
    
    // If IR sensor detects object, the return will be HIGH
    Serial.print("\tRight IR: ");
    if ( rightObstacle() ) {
      turnOnRedLED();        // Turn red LED on if detected
      Serial.println("1");
    }
    else {
      turnOffRedLED();       // Turn red LED off if not detected
      Serial.println("0");
    }
    
    delay(1000);
  }
  
}

void performLDRTest()
{
  clearSerial();
  Serial.println("Welcome to the LDR Test. Send 'c' to exit.\n"); 

  while (Serial.available() == 0)
  {
    Serial.print("Left Photoresistor: ");
    Serial.println( getLeftLight() );
    
    Serial.print("Right Photoresistor: ");
    Serial.println( getRightLight() );
    
    delay(1000);
  }
}

void performLEDTest()
{
  clearSerial();
  Serial.println("Welcome to the LED Test. Send 'c' to exit.\n");

  int time = 500;
  
  while (Serial.available() == 0)
  {
    turnOnGreenLED();
    Serial.println("Green On");
    delay(time);                 // wait for a second
    turnOffGreenLED();
    Serial.println("Green Off");
    delay(time);                 // wait for a second
    
    // Perform same as above with the red LED
    turnOnRedLED();
    Serial.println("Red On");
    delay(time);
    turnOffRedLED();
    Serial.println("Red Off");
    delay(time);
  }
}

void performSpeakerTest()
{
  clearSerial();
  Serial.println("Welcome to the Speaker Test. Send 'c' to exit.\n");

  int length = 500;
  
  while (Serial.available() == 0)
  {
    Serial.println("Speaker on.");
  
    playSound(262, length); // C4
    delay(length);
    playSound(294, length); // D4
    delay(length);
    playSound(330, length); // E4
    delay(length);
    playSound(349, length); // F4
    delay(length);
    playSound(392, length); // G4
    delay(length);
    playSound(440, length); // A4
    delay(length);
    playSound(494, length); // B4
    delay(length);
    playSound(523, length); // C4
    delay(length);
    
    Serial.println("Speaker off.");

    delay(5000);
  }
}

void clearSerial()
{
  for (int i = 0; i < 25; i++)
  {
    Serial.println();
  }
}

