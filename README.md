# CrisalixProject
Project has one scene 4 game objects and 1 main canvas
Canvas has buttons for ball attributes and create ball
Every button has scripts derived from BaseButtonBehaviour 
Base behaviour has one method for onclick because every button would need it
Ball attribute buttons has two child objects for color and size 
Size child object is a slider because it is easier to control amount
Color child object is dropdown because it is useful for multiple choice
Every button script has onColorchange and onSizechange metods which connected to GameManager script for respective behaviors
