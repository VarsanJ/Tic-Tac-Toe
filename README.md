# Purpose of Project
The purpose of this project was to design a one-player tic-tac-toe game where the computer player makes smart moves

# Gameplay Instructions
Initially, the user selects who makes the first move (computer vs player) using the button selection. After this point, the computer and user make moves on the board in order to make three squares in a row, column or diagonal the same symbol. Each of the user and the player has their own symbol (X and O). If there is a tie/win/lose, the game will indicate that and add to the overall score. The user then has the option to reset the board and start the game again. At any point, the user has the option to terminate their game. 

# Computer Information
In order to create a smart functional game, a magic number format is used. Each square is assigned a distinct one-digit integer. The sum of every row/column/diagonal comes to 15. This enables the computer to detect which square is needed to win the game or block an attack by the user. Certain specific scenarios are built into the computer (eg. tendencies to select the center/diagonal, specific scenarios). The objective was to make the computer as unbeatable as possible. 
