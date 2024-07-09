//Name: Varsan Jeyakkumar
//Date: 2024-05-14 (START)
//Title: TicTacToe
//Purpose: To design a one-player tic-tac-toe game with a smart computer using a windows form application

using A9VarsanJ___TicTacToe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A9VarsanJ___TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Welcome User To Tic Tac Toe\nPlease select who goes first!\nDesigned By Varsan Jeyakkumar"); //initial instructions
        }

        //Variable Declaration
        bool boolIsOneClicked = false, boolIsTwoClicked = false, boolIsThreeClicked = false, boolIsFourClicked = false, boolIsFiveClicked = false, boolIsSixClicked = false, boolIsSevenClicked = false, boolIsEightClicked = false, boolIsNineClicked = false; //sets click variables
        int intPlayerCounter = 0, intComputerCounter = 0; //sets move turn counters to demonstrate to the user
        Random randomComputerChoice = new Random(); //enables random to enable the computer to make a choice regarding the user move
        int[] intComputerMoves = { -99, -99, -99, -99, -99 }, intPlayerMoves = { -99, -99, -99, -99, -99 }; //creates array to store the moves performed by user and computer
        int intWins = 0, intLoss = 0, intTies = 0; //Shows the number of each type of score
        int intNumberGamesCounter = 0; //Establishes a counter for the number of games
        bool boolIsEnd = false; //Establishes a boolean to determine outcomes 
        bool boolIsEven = false; //Estabkishes a boolean so that the first or second move is to select an even number
        bool boolIsRandom = false; //establishes a boolean if necessary proceed with random

        //Runs the method when the computer selection is required
        public void ComputerMove()
        {
            boolIsRandom = true;
            intComputerCounter++; //Adds a computer move
            if (boolIsFiveClicked == false) //selects the center square if not selected, otherwise this code is bypassed by the computer
            {
                boolIsFiveClicked = true;
                this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                checkwin(); //checks all ending situations
            }
            else if ((intComputerMoves[0] == 5) && (intComputerMoves[1] == -99) && (intPlayerMoves[0] % 2 == 0) && (intPlayerMoves[1] % 2 == 0) && (intPlayerMoves[2] == -99)) //two corners and center defence
            {
                int intRandom;
                intRandom = randomComputerChoice.Next(1, 5);
                boolIsEven = false; //disables variables to prevent another scenario
                boolIsRandom = true;
                if (boolIsRandom == true)
                {
                    CompDefence();
                }
                if (boolIsRandom == true)
                {
                    CompDefence2();
                }
                if (boolIsRandom == true)
                {
                    CompDefence3();
                }
                if (boolIsRandom == true)
                {
                    if (intRandom == 1)
                    {
                        boolIsTwoClicked = true;
                        this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                        this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                        intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                        checkwin();
                    }
                    else if (intRandom == 2)
                    {
                        boolIsFourClicked = true;
                        this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                        this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                        intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                        checkwin(); //checks all ending situations
                    }
                    else if (intRandom == 3)
                    {
                        boolIsSixClicked = true;
                        this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                        this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                        intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                        checkwin(); //checks all ending situations
                    }
                    else if (intRandom == 4)
                    {
                        boolIsEightClicked = true;
                        this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                        this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                        intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                        checkwin(); //checks all ending situations
                    }
                }
            }

            else if ((intPlayerMoves[0] == 5) && (intPlayerMoves[1] == -99) && (intComputerMoves[0] == -99))
            {
                //Ensure that when the user picks center, computer picks corner
                int intRandom = 0;
                intRandom = randomComputerChoice.Next(1, 5);
                boolIsEven = false; //disables variables to prevent another scenario
                boolIsRandom = true;
                if ((intRandom == 1) && (boolIsOneClicked == false)) //checks button if choice available
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                }
                else if ((intRandom == 2) && (boolIsThreeClicked == false)) //checks button if choice available
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                }
                else if ((intRandom == 3) && (boolIsSevenClicked == false)) //checks button if choice available
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                }
                else if ((intRandom == 4) && (boolIsNineClicked == false)) //checks button if choice available
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                }
            }
            else if (boolIsEven == false) //second move
            {
                if (boolIsRandom == true)
                {
                    CompAttack(); //tries an offensive move if needed
                }
                if (boolIsRandom == true)
                {
                    CompAttack2();
                }
                if (boolIsRandom == true)
                {
                    CompAttack3();
                }
                //All attack win scenarios run, none detected
                if (boolIsRandom == true)
                {
                    CompDefence();
                }
                if (boolIsRandom == true)
                {
                    CompDefence2();
                }
                if (boolIsRandom == true)
                {
                    CompDefence3();
                }
                //All defense lose scenarios run, no imminent loss 
                if (boolIsEven == false)
                {
                    while (true)
                    {
                        int intRandomMove = randomComputerChoice.Next(1, 5); //Selects random choice to select
                        boolIsEven = true;
                        if ((intRandomMove == 1) && (boolIsOneClicked == false)) //checks button if choice available
                        {
                            boolIsOneClicked = true;
                            this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 2) && (boolIsThreeClicked == false)) //checks button if choice available
                        {
                            boolIsThreeClicked = true;
                            this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnTopRight.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 3) && (boolIsSevenClicked == false)) //checks button if choice available
                        {
                            boolIsSevenClicked = true;
                            this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                            checkwin();
                            break;
                        }
                        else if ((intRandomMove == 4) && (boolIsNineClicked == false)) //checks button if choice available
                        {
                            boolIsNineClicked = true;
                            this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                    }
                }

            }
            else
            {
                boolIsRandom = true;
                if (boolIsRandom == true)
                {
                    CompAttack(); //tries an offensive move if needed
                }
                if (boolIsRandom == true)
                {
                    CompAttack2();
                }
                if (boolIsRandom == true)
                {
                    CompAttack3();
                }
                if (boolIsRandom == true)
                {
                    CompDefence();
                }
                if (boolIsRandom == true)
                {
                    CompDefence2();
                }
                if (boolIsRandom == true)
                {
                    CompDefence3();
                }

                if (boolIsRandom == true) //random selection always a last resort
                {
                    while (true)
                    {
                        int intRandomMove = randomComputerChoice.Next(1, 10); //Selects random choice to select

                        if ((intRandomMove == 1) && (boolIsOneClicked == false)) //checks button if choice available
                        {
                            boolIsOneClicked = true;
                            this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 2) && (boolIsTwoClicked == false)) //checks button if choice available
                        {
                            boolIsTwoClicked = true;
                            this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                            checkwin();
                            break;
                        }
                        else if ((intRandomMove == 3) && (boolIsThreeClicked == false)) //checks button if choice available
                        {
                            boolIsThreeClicked = true;
                            this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnTopRight.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 4) && (boolIsFourClicked == false)) //checks button if choice available
                        {
                            boolIsFourClicked = true;
                            this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                            intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 5) && (boolIsFiveClicked == false)) //checks button if choice available
                        {
                            boolIsFiveClicked = true;
                            this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 6) && (boolIsSixClicked == false)) //checks button if choice available
                        {
                            boolIsSixClicked = true;
                            this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 7) && (boolIsSevenClicked == false)) //checks button if choice available
                        {
                            boolIsSevenClicked = true;
                            this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                            checkwin();
                            break;
                        }
                        else if ((intRandomMove == 8) && (boolIsEightClicked == false)) //checks button if choice available
                        {
                            boolIsEightClicked = true;
                            this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                        else if ((intRandomMove == 9) && (boolIsNineClicked == false)) //checks button if choice available
                        {
                            boolIsNineClicked = true;
                            this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                            this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                            intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                            checkwin(); //checks all ending situations
                            break;
                        }
                    }
                }


            }
        }

        //Computer Defense Moves
        public void CompDefence()
        {
            int intSum, intDiff;
            int intZero = 0, intOne = 1, intTwo = 2;
            if ((intPlayerMoves[intOne] > -99) && (intPlayerMoves[intTwo] == -99)) //Checks the first two moves to see if defendable
            {
                intSum = intPlayerMoves[intOne] + intPlayerMoves[intZero];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
        }

        public void CompDefence2()
        {
            int intSum, intDiff;
            if ((intPlayerMoves[2] > -99) && (intPlayerMoves[3] == -99))
            {
                intSum = intPlayerMoves[2] + intPlayerMoves[0];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }

            }
            if ((intPlayerMoves[2] > -99) && (intPlayerMoves[3] == -99) && (boolIsRandom == true))
            {
                intSum = intPlayerMoves[2] + intPlayerMoves[1];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }

        }
        public void CompDefence3()
        {
            int intSum, intDiff;
            if ((intPlayerMoves[3] > -99) && (intPlayerMoves[4] == -99))
            {
                intSum = intPlayerMoves[3] + intPlayerMoves[0];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }

            }
            if ((intPlayerMoves[3] > -99) && (intPlayerMoves[4] == -99) && (boolIsRandom == true))
            {
                intSum = intPlayerMoves[3] + intPlayerMoves[1];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
            if ((intPlayerMoves[3] > -99) && (intPlayerMoves[4] == -99) && (boolIsRandom == true))
            {
                intSum = intPlayerMoves[3] + intPlayerMoves[2];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
        }

        //Computer Attack Moves
        public void CompAttack() //ATTACK TRY 1
        {
            int intSum, intDiff;
            int intZero = 0, intOne = 1, intTwo = 2;
            if ((intComputerMoves[intOne] > -99) && (intComputerMoves[intTwo] == -99)) //Checks the first two moves to see if defendable
            {
                intSum = intComputerMoves[intOne] + intComputerMoves[intZero];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
        }

        public void CompAttack2()
        {
            int intSum, intDiff;
            if ((intComputerMoves[2] > -99) && (intComputerMoves[3] == -99))
            {
                intSum = intComputerMoves[2] + intComputerMoves[0];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }

            }
            if ((intComputerMoves[2] > -99) && (intComputerMoves[3] == -99) && (boolIsRandom == true))
            {
                intSum = intComputerMoves[2] + intComputerMoves[1];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }

        }

        public void CompAttack3()
        {
            int intSum, intDiff;
            if ((intComputerMoves[3] > -99) && (intComputerMoves[4] == -99))
            {
                intSum = intComputerMoves[3] + intComputerMoves[0];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }

            }
            if ((intComputerMoves[3] > -99) && (intComputerMoves[4] == -99) && (boolIsRandom == true))
            {
                intSum = intComputerMoves[3] + intComputerMoves[1]; //runs the sum of move #3 and move #1
                intDiff = 15 - intSum; //calculates the difference
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
            if ((intComputerMoves[3] > -99) && (intComputerMoves[4] == -99) && (boolIsRandom == true))
            {
                intSum = intComputerMoves[3] + intComputerMoves[2];
                intDiff = 15 - intSum;
                if ((intDiff == 2) && (boolIsOneClicked == false))
                {
                    boolIsOneClicked = true;
                    this.btnTopLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 2; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 9) && (boolIsTwoClicked == false))
                {
                    boolIsTwoClicked = true;
                    this.btnTopMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 9; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 4) && (boolIsThreeClicked == false))
                {
                    boolIsThreeClicked = true;
                    this.btnTopRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnTopRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 4; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 7) && (boolIsFourClicked == false))
                {
                    boolIsFourClicked = true;
                    this.btnMiddleLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game 
                    intComputerMoves[intComputerCounter - 1] = 7; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 5) && (boolIsFiveClicked == false))
                {
                    boolIsFiveClicked = true;
                    this.btnMiddleCenter.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 5; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 3) && (boolIsSixClicked == false))
                {
                    boolIsSixClicked = true;
                    this.btnMiddleRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 3; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 6) && (boolIsSevenClicked == false))
                {
                    boolIsSevenClicked = true;
                    this.btnBottomLeft.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 6; //adds the value to corresponding aray
                    checkwin();
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 1) && (boolIsEightClicked == false))
                {
                    boolIsEightClicked = true;
                    this.btnBottomMiddle.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 1; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
                else if ((intDiff == 8) && (boolIsNineClicked == false))
                {
                    boolIsNineClicked = true;
                    this.btnBottomRight.Text = "O"; //sets corresponding box display per who chose the box
                    this.btnBottomRight.Enabled = false; //disables selected box for remaining game
                    intComputerMoves[intComputerCounter - 1] = 8; //adds the value to corresponding aray
                    checkwin(); //checks all ending situations
                    boolIsRandom = false; //sets random false since move done
                    boolIsEven = true;
                }
            }
        }

        //Initial Decision Selection
        private void btnComputerFirst_Click(object sender, EventArgs e)
        {
            //Disables Choice To Start Before Computer Move
            this.btnUserFirst.Enabled = false;
            this.btnComputerFirst.Enabled = false;
            intNumberGamesCounter++;
            this.lblStatusCurrent.Text = intNumberGamesCounter + " Game(s)";

            //Enables User Choice Buttons
            this.btnBottomLeft.Enabled = true;
            this.btnBottomRight.Enabled = true;
            this.btnBottomMiddle.Enabled = true;
            this.btnMiddleCenter.Enabled = true;
            this.btnMiddleRight.Enabled = true;
            this.btnMiddleLeft.Enabled = true;
            this.btnTopLeft.Enabled = true;
            this.btnTopRight.Enabled = true;
            this.btnTopMiddle.Enabled = true;

            //Disables reset
            this.btnReset.Enabled = false;

            //Runs one computer move
            ComputerMove();

            //Enables picture 
            this.pblStatusPicture.Image = StatusPictures.Good_Luck;
        }

        private void btnUserFirst_Click(object sender, EventArgs e)
        {
            //Disables Choice To Start Without doing Computer Move
            this.btnUserFirst.Enabled = false;
            this.btnComputerFirst.Enabled = false;
            intNumberGamesCounter++;
            this.lblStatusCurrent.Text = intNumberGamesCounter + " Game(s)";

            //Enables User Choice Buttons
            this.btnBottomLeft.Enabled = true;
            this.btnBottomRight.Enabled = true;
            this.btnBottomMiddle.Enabled = true;
            this.btnMiddleCenter.Enabled = true;
            this.btnMiddleRight.Enabled = true;
            this.btnMiddleLeft.Enabled = true;
            this.btnTopLeft.Enabled = true;
            this.btnTopRight.Enabled = true;
            this.btnTopMiddle.Enabled = true;

            //Disables reset
            this.btnReset.Enabled = false;

            //Enables picture 
            this.pblStatusPicture.Image = StatusPictures.Good_Luck;
        }

        //Exits the Code
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Terminates the Program
        }

        //Resets the Code
        private void btnReset_Click(object sender, EventArgs e)
        {
            //Resets the text
            this.btnBottomLeft.Text = "";
            this.btnBottomRight.Text = "";
            this.btnBottomMiddle.Text = "";
            this.btnMiddleCenter.Text = "";
            this.btnMiddleRight.Text = "";
            this.btnMiddleLeft.Text = "";
            this.btnTopLeft.Text = "";
            this.btnTopRight.Text = "";
            this.btnTopMiddle.Text = "";

            //Disables choice buttons
            this.btnBottomLeft.Enabled = false;
            this.btnBottomRight.Enabled = false;
            this.btnBottomMiddle.Enabled = false;
            this.btnMiddleCenter.Enabled = false;
            this.btnMiddleRight.Enabled = false;
            this.btnMiddleLeft.Enabled = false;
            this.btnTopLeft.Enabled = false;
            this.btnTopRight.Enabled = false;
            this.btnTopMiddle.Enabled = false;

            //Enables the who goes first buttons
            this.btnComputerFirst.Enabled = true;
            this.btnUserFirst.Enabled = true;

            //Erases arrays
            intComputerMoves = new int[] { -99, -99, -99, -99, -99 };
            intPlayerMoves = new int[] { -99, -99, -99, -99, -99 };

            //Resets new game and other variables
            boolIsEnd = false;
            boolIsOneClicked = false;
            boolIsTwoClicked = false;
            boolIsThreeClicked = false;
            boolIsFourClicked = false;
            boolIsFiveClicked = false;
            boolIsSixClicked = false;
            boolIsSevenClicked = false;
            boolIsEightClicked = false;
            boolIsNineClicked = false;
            intPlayerCounter = 0;
            intComputerCounter = 0;

            MessageBox.Show("Reset game\nPlease select who goes first!");
            this.lblStatusCurrent.Text = "Please select Starter";
        }

        //Button Clicks
        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 2;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnTopLeft.Enabled = false; //disables selected box for remaining game
            this.btnTopLeft.Text = "X"; //sets corresponding box display per who chose the box
            boolIsOneClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnTopMiddle_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 9;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnTopMiddle.Enabled = false; //disables selected box for remaining game
            this.btnTopMiddle.Text = "X"; //sets corresponding box display per who chose the box
            boolIsTwoClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 4;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnTopRight.Enabled = false; //disables selected box for remaining game
            this.btnTopRight.Text = "X"; //sets corresponding box display per who chose the box
            boolIsThreeClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnMiddleLeft_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 7;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnMiddleLeft.Enabled = false; //disables selected box for remaining game
            this.btnMiddleLeft.Text = "X"; //sets corresponding box display per who chose the box
            boolIsFourClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnMiddleCenter_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 5;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnMiddleCenter.Enabled = false; //disables selected box for remaining game
            this.btnMiddleCenter.Text = "X"; //sets corresponding box display per who chose the box
            boolIsFiveClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnMiddleRight_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 3;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnMiddleRight.Enabled = false; //disables selected box for remaining game
            this.btnMiddleRight.Text = "X"; //sets corresponding box display per who chose the box
            boolIsSixClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnBottomLeft_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 6;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnBottomLeft.Enabled = false; //disables selected box for remaining game
            this.btnBottomLeft.Text = "X"; //sets corresponding box display per who chose the box
            boolIsSevenClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnBottomMiddle_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 1;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnBottomMiddle.Enabled = false; //disables selected box for remaining game
            this.btnBottomMiddle.Text = "X"; //sets corresponding box display per who chose the box
            boolIsEightClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }

        private void btnBottomRight_Click(object sender, EventArgs e)
        {
            intPlayerCounter++; //adds to player counter and assigns button value
            int intBtnValue = 8;
            intPlayerMoves[intPlayerCounter - 1] = intBtnValue; //adds the value to corresponding aray
            this.btnBottomRight.Enabled = false; //disables selected box for remaining game
            this.btnBottomRight.Text = "X"; //sets corresponding box display per who chose the box
            boolIsNineClicked = true;
            checkwin(); //checks all possible end outcomes

            if (boolIsEnd == false) //sets computer to run a move if game not ended
            {
                ComputerMove();
            }
        }
        public void checkwin()
        {
            checkplayerwin(); //Checks if user wins
            if (boolIsEnd == false)
            {
                checkcomputerwin(); //Checks if computer wins
            }
            if (boolIsEnd == false)
            {
                checktie(); //Checks if there is a tie
            }
            if (boolIsEnd == true) //Activates the end procedure
            {
                //disables all of the tic tac toe buttons in order to end the current game
                this.btnBottomLeft.Enabled = false;
                this.btnBottomRight.Enabled = false;
                this.btnBottomMiddle.Enabled = false;
                this.btnMiddleCenter.Enabled = false;
                this.btnMiddleRight.Enabled = false;
                this.btnMiddleLeft.Enabled = false;
                this.btnTopLeft.Enabled = false;
                this.btnTopRight.Enabled = false;
                this.btnTopMiddle.Enabled = false;

                //enables the reset option so that user can start a new code for the game
                this.btnReset.Enabled = true;

                //remakes the code to display the score
                this.lblScore.Text = intWins + " WIN(S), " + intLoss + " LOSS, " + intTies + " TIE(S)";
            }
        }
        public void checkcomputerwin()
        {
            //Checks all possible computer wins and changes counter, status and displays loss if there is loss
            if (intComputerMoves[0] + intComputerMoves[1] + intComputerMoves[2] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[0] + intComputerMoves[1] + intComputerMoves[3] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[0] + intComputerMoves[1] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[0] + intComputerMoves[2] + intComputerMoves[3] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[0] + intComputerMoves[2] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[0] + intComputerMoves[3] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[1] + intComputerMoves[2] + intComputerMoves[3] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[1] + intComputerMoves[2] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[1] + intComputerMoves[3] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }
            else if (intComputerMoves[2] + intComputerMoves[3] + intComputerMoves[4] == 15)
            {
                intLoss++;
                boolIsEnd = true;
                MessageBox.Show("You lost!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Losing;
            }

        }
        public void checkplayerwin()
        {
            //Checks all possible player wins and changes counter, status and displays win if there is win
            if (intPlayerMoves[0] + intPlayerMoves[1] + intPlayerMoves[2] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[0] + intPlayerMoves[1] + intPlayerMoves[3] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[0] + intPlayerMoves[1] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[0] + intPlayerMoves[2] + intPlayerMoves[3] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[0] + intPlayerMoves[2] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[0] + intPlayerMoves[3] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[1] + intPlayerMoves[2] + intPlayerMoves[3] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[1] + intPlayerMoves[2] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[1] + intPlayerMoves[3] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
            else if (intPlayerMoves[2] + intPlayerMoves[3] + intPlayerMoves[4] == 15)
            {
                intWins++;
                boolIsEnd = true;
                MessageBox.Show("You Win!");
                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Winning;
            }
        }
        public void checktie()
        {
            //If all  boxes are filled without a win or a loss, it means that the game has ended in a tie
            if ((intComputerCounter + intPlayerCounter == 9))
            {
                MessageBox.Show("The game ended in a tie!");
                intTies++;
                boolIsEnd = true;

                //Enables picture 
                this.pblStatusPicture.Image = StatusPictures.Tie;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}




