# Overview

This code uses the built-in character controller component and the new Input System to power the movement mechanics. 

The code is modular, so it's easier to understand. 

There's no comments inside the code, to reduce lines and make it easier to understand. However, here I will be explaining every part of the code.

It's very easy to modify the code to suit your needs and to change between first person and third person, however the code is made entirely for first person use. 

# Code Explanation

The player is the "Player Manager" object inside the hierarchy. It manages every single action the player can do. Inside the object there's the capsule that acts as a visual representation of the player, though it's not needed if you don't want it. 

Let's dive first into Scene. Here you will only see a plane, **it is in a ground layer** this will be important for later. You will also see the player. 

In the inspector you will see the PlayerManager object, the plane and the directional light, but the camera will be inside the PlayerManager object, as it will be constantly working with it, you can move it if you want, but it's easier to leave it there. 

Now, let's dive into the CameraControl script, which manages the rotation of the camera based on the mouse position and rotates the player also based on the rotation of the camera. 

Inside the script you will first see 3 variables, `mouseSensitivity`, `player` and `rotation`. The first one is self explanatory, the second one references the player, so that it can rotate it, and the last one stores the camera rotation. Then in the start and update method it locks the cursor and does the math for the camera rotation.

Now for the Movement script, the first two variables reference the Input System (Contols) and the character controller, then there's the normal and running speed for walking and running respectively, and in the gravity section, there are 4 variables, the first one (`groundCheck`) stores the GroundCheck gameobject's position to constantly check if you are grounded or not, the `gravity` variable for declaring the player's gravity, the `groundRadius` variable stores a float value for checking if we are grounded or not, and the `groundMask` variable stores a LayerMask for what layers we can walk or not. Then it's the `jumpHeight` variable stores how much we can jump. Then we run into the private variables, `currentSpeed` to change between `normalSpeed` and `runningSpeed`, the bool `isGrounded` to store if we are grounded or not and the `velocity` variable for the physics section. 

Now into the code, the Input System region declares and takes care of the Input System part. Then at the start function we reference our character controller and set the `currentSpeed` = `normalSpeed`. In the `update` function we create a sphere around the `groundCheck` position, using the other 3 variables and then we reference the `move` and `physics` functions. 

That's pretty much it 

# Extra Notes

This is outside the code, but I wan't to give a huge thank you to those that use this code. It's my first time making a public repo, but I have been wanting to do it. I'm somewhat new to code, but I feel this code is pretty good for it's use. 

So again, thanks for everything, hope the code helps you. Any requests, issues, comments please feel free to tell me. 

I'm planning on adding crouching, so please tell me if you would like that. 

This repo was made on April 4th 2021, and is planned to stop updating on April 30th 2021.
