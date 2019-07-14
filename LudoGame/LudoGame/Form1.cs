using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LudoGame
{
   
    public partial class Form1 : Form
    {
        int dice = 0;
        string[] colorTurn = { "green", "red", "blue", "yellow"};
        string []result = new string[5];
        
        int i = 0;
        public Form1(string green, string red, string blue, string yellow)
        {
            InitializeComponent();
            result[0] = green;
            result[1] = red;
            result[2] = blue;
            result[3] = yellow;
            result[4] = "null";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dice = game.throwDice();
            switch (dice){
                case 1:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_00.gif";
                    break;
                case 2:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_01.gif";
                    break;
                case 3:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_02.gif";
                    break;
                case 4:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_03.gif";
                    break;
                case 5:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_04.gif";
                    break;
                case 6:
                    pictureBox1.ImageLocation = @"C:\Users\Iqdar Shah\source\repos\LudoGame\AW385985_05.gif";
                    break;
            }
            if (game.canItMove(colorTurn[i], dice) == false)
            {
                dice = 0;
                if (i == 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                label1.Text = colorTurn[i] + "'s turn";
            }
            else
            {
                button1.Hide();
                
            }
        }

        private void green1_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "green" && dice !=0)
            {
                status = game.moveToken("green", 1, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("green", game.green[0, 0]);
                    if (throwIn!=0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("green");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1) {
                green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));

                if (dice != 6 && rethrowDice == 0)
                {
                    if (i == 3)
                    {
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                        
                    label1.Text = colorTurn[i] + "'s turn";
                }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.green[0, 0] > 75)
            {
                green1.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = colorTurn[i] + "'s turn";
            blue1.BringToFront();
            blue2.BringToFront();
            blue3.BringToFront();
            blue4.BringToFront();
            green1.BringToFront();
            green2.BringToFront();
            green3.BringToFront();
            green4.BringToFront();
            red1.BringToFront();
            red2.BringToFront();
            red3.BringToFront();
            red4.BringToFront();
            yellow1.BringToFront();
            yellow2.BringToFront();
            yellow3.BringToFront();
            yellow4.BringToFront();
            yellow1.BringToFront();
        }

        private void green2_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "green" && dice != 0)
            {
                status = game.moveToken("green", 2, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("green", game.green[1, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("green");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        
                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.green[1, 0] > 75)
            {
                green2.Hide();
            }
        }

        private void green3_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "green" && dice != 0)
            {
                status = game.moveToken("green", 3, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("green", game.green[2, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("green");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.green[2, 0] > 75)
            {
                green3.Hide();
            }
        }

        private void green4_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "green" && dice != 0)
            {
                status = game.moveToken("green", 4, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("green", game.green[3, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("green");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.green[3, 0] > 75)
            {
                green4.Hide();
            }
        }

        private void red1_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "red" && dice != 0)
            {
                status = game.moveToken("red", 1, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("red", game.red[0, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("red");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));

                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.red[0, 0] > 85)
            {
                red1.Hide();
            }
        }

        private void red2_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "red" && dice != 0)
            {
                status = game.moveToken("red", 2, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("red", game.red[1, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("red");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.red[1, 0] > 85)
            {
                red2.Hide();
            }
        }

        private void red3_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "red" && dice != 0)
            {
                status = game.moveToken("red", 3, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("red", game.red[2, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("red");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.red[2, 0] > 85)
            {
                red3.Hide();
            }
        }

        private void red4_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "red" && dice != 0)
            {
                status = game.moveToken("red", 4, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("red", game.red[3, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("red");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.red[3, 0] > 85)
            {
                red4.Hide();
            }
        }

        private void blue1_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "blue" && dice != 0)
            {
                status = game.moveToken("blue", 1, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("blue", game.blue[0, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("blue");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.blue[0, 0] > 95)
            {
                blue1.Hide();
            }
        }

        private void blue2_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "blue" && dice != 0)
            {
                status = game.moveToken("blue", 2, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("blue", game.blue[1, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("blue");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.blue[1, 0] > 95)
            {
                blue2.Hide();
            }
        }

        private void blue3_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "blue" && dice != 0)
            {
                status = game.moveToken("blue", 3, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("blue", game.blue[2, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("blue");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.blue[2, 0] > 95)
            {
                blue3.Hide();
            }
        }

        private void blue4_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "blue" && dice != 0)
            {
                status = game.moveToken("blue", 4, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("blue", game.blue[3, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("blue");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.blue[3, 0] > 95)
            {
                blue4.Hide();
            }
        }

        private void yellow1_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "yellow" && dice != 0)
            {
                status = game.moveToken("yellow", 1, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("yellow", game.yellow[0, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("yellow");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.yellow[0, 0] > 65)
            {
                yellow1.Hide();
            }
        }

        private void yellow2_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "yellow" && dice != 0)
            {
                status = game.moveToken("yellow", 2, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("yellow", game.yellow[1, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("yellow");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.yellow[1, 0] > 65)
            {
                yellow2.Hide();
            }
        }

        private void yellow3_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "yellow" && dice != 0)
            {
                status = game.moveToken("yellow", 3, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("yellow", game.yellow[2, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("yellow");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.yellow[2, 0] > 65)
            {
                yellow3.Hide();
            }
        }

        private void yellow4_Click(object sender, EventArgs e)
        {
            int status = 0;
            int throwIn = 1;
            int rethrowDice = 0;
            if (colorTurn[i] == "yellow" && dice != 0)
            {
                status = game.moveToken("yellow", 4, dice);
                while (throwIn != 0)
                {
                    throwIn = game.throwTokenIn("yellow", game.yellow[3, 0]);
                    if (throwIn != 0)
                    {
                        rethrowDice = 1;
                        game.afterThrowChangeStatus("yellow");
                    }
                    switch (throwIn)
                    {
                        case 1:
                            green1.Location = new Point(game.xPosition("green", 1), game.yPosition("green", 1));
                            break;
                        case 2:
                            green2.Location = new Point(game.xPosition("green", 2), game.yPosition("green", 2));
                            break;
                        case 3:
                            green3.Location = new Point(game.xPosition("green", 3), game.yPosition("green", 3));
                            break;
                        case 4:
                            green4.Location = new Point(game.xPosition("green", 4), game.yPosition("green", 4));
                            break;
                        case 5:
                            yellow1.Location = new Point(game.xPosition("yellow", 1), game.yPosition("yellow", 1));
                            break;
                        case 6:
                            yellow2.Location = new Point(game.xPosition("yellow", 2), game.yPosition("yellow", 2));
                            break;
                        case 7:
                            yellow3.Location = new Point(game.xPosition("yellow", 3), game.yPosition("yellow", 3));
                            break;
                        case 8:
                            yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                            break;
                        case 9:
                            blue1.Location = new Point(game.xPosition("blue", 1), game.yPosition("blue", 1));
                            break;
                        case 10:
                            blue2.Location = new Point(game.xPosition("blue", 2), game.yPosition("blue", 2));
                            break;
                        case 11:
                            blue3.Location = new Point(game.xPosition("blue", 3), game.yPosition("blue", 3));
                            break;
                        case 12:
                            blue4.Location = new Point(game.xPosition("blue", 4), game.yPosition("blue", 4));
                            break;
                        case 13:
                            red1.Location = new Point(game.xPosition("red", 1), game.yPosition("red", 1));
                            break;
                        case 14:
                            red2.Location = new Point(game.xPosition("red", 2), game.yPosition("red", 2));
                            break;
                        case 15:
                            red3.Location = new Point(game.xPosition("red", 3), game.yPosition("red", 3));
                            break;
                        case 16:
                            red4.Location = new Point(game.xPosition("red", 4), game.yPosition("red", 4));
                            break;
                    }
                }
                if (status == 1)
                {
                    yellow4.Location = new Point(game.xPosition("yellow", 4), game.yPosition("yellow", 4));
                    if (dice != 6 && rethrowDice == 0)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                        label1.Text = colorTurn[i] + "'s turn";
                    }
                    dice = 0;
                    int j = 0;
                    while (game.throwDicePermission(colorTurn[i]) == false)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        j++;
                        if (j > 4)
                        {
                            MessageBox.Show("Game Ended");
                            this.Close();
                        }
                    }
                    label1.Text = colorTurn[i] + "'s turn";
                    button1.Show();
                }

            }
            if (game.yellow[3, 0] > 65)
            {
                yellow4.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "1";
                try
                {

                    XmlTextReader reader = new XmlTextReader("C:\\Users\\Iqdar Shah\\source\\repos\\LudoGame\\Data\\MaxID.xml");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.LocalName.Equals("MaxID"))
                            {
                                id = "" + reader.ReadString();
                                MessageBox.Show("Game id: "+(Convert.ToInt32(id)+1));
                                reader.Close();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error during read");
                }
                XmlTextWriter xml = new XmlTextWriter("C:\\Users\\Iqdar Shah\\source\\repos\\LudoGame\\Data\\ID_"+ (Convert.ToInt32(id) + 1).ToString() + ".xml", null);
                xml.WriteStartDocument();
                xml.Indentation = 6;
                xml.WriteComment("Data of Game");

                xml.WriteStartElement("", "Data", "");

                xml.WriteStartElement("","First", "");
                xml.WriteString(game.positions[0]+" "+result[Array.IndexOf(result,game.positions[0])]);
                xml.WriteEndElement();
                xml.WriteStartElement("", "Second", "");
                xml.WriteString(game.positions[1] + " " + result[Array.IndexOf(result, game.positions[1])]);
                xml.WriteEndElement();
                xml.WriteStartElement("", "Third", "");
                xml.WriteString(game.positions[2] + " " + result[Array.IndexOf(result, game.positions[2])]);
                xml.WriteEndElement();
                xml.WriteStartElement("", "Fourth", "");
                xml.WriteString(game.positions[3] + " " + result[Array.IndexOf(result, game.positions[3])]);
                xml.WriteEndElement();
                xml.WriteEndElement();
                xml.Flush();
                xml.Close();

                XmlTextWriter xml2 = new XmlTextWriter("C:\\Users\\Iqdar Shah\\source\\repos\\LudoGame\\Data\\MaxID.xml", null);
                xml2.WriteStartDocument();
                xml2.Indentation = 6;
                xml2.WriteComment("Data of GameID");
                xml2.WriteStartElement("", "MaxID", "");
                xml2.WriteString(Convert.ToString(Convert.ToInt32(id)+1));
                xml2.WriteEndElement();
                xml2.Flush();
                xml2.Close();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }


}

class game
{
    public static int[,] red = new int[4, 3];
    public static int[,] blue = new int[4, 3];
    public static int[,] green = new int[4, 3];
    public static int[,] yellow = new int[4, 3];
    public static string[] positions = { "null", "null", "null", "null" };
    public static int pos = 0;

    public static void initializeTokens(String color, int tokenNum)
    {
        switch (color){
            case "green":
                green[tokenNum - 1, 0] = 0;
                break;
            case "red":
                red[tokenNum - 1, 0] = 0;
                break;
            case "blue":
                blue[tokenNum - 1, 0] = 0;
                break;
            case "yellow":
                yellow[tokenNum - 1, 0] = 0;
                break;
        }
    }

    public static int throwDice()
    {
        Random rnd = new Random();
        int dicePoint = rnd.Next(1, 7);
        return dicePoint;
    }

    public static bool canItMove(string color, int dicePoints)
    {
        bool x = true;
        switch (color)
        {
            case "green":
                if ((green[0, 0] == 0 || green[0, 0] > 75) && (green[1, 0] == 0 || green[1, 0] > 75) && (green[2, 0] == 0 || green[2, 0] > 75) && (green[3, 0] == 0 || green[3, 0] > 75) && dicePoints != 6)
                {
                    x = false;
                }
                else if ((((green[0,0]+dicePoints>13 && green[0,0]<14) || (green[0,0]==0 && dicePoints !=6)) && ((green[1, 0] + dicePoints > 13 && green[1,0]<14) || (green[1, 0] == 0 && dicePoints != 6)) && ((green[2, 0] + dicePoints > 13 && green[2,0] <14 ) || (green[2, 0] == 0 && dicePoints != 6)) && ((green[3, 0] + dicePoints > 13 && green[3, 0] < 14) || (green[3, 0] == 0 && dicePoints != 6))) &&(green[0,2] == 0))
                {
                    x = false;
                }
                break;
            case "blue":
                if ((blue[0, 0] == 0 || blue[0, 0] > 95) && (blue[1, 0] == 0 || blue[1, 0] > 95) && (blue[2, 0] == 0 || blue[2, 0] > 95) && (blue[3, 0] == 0 || blue[3, 0] > 95) && dicePoints != 6)
                {
                    x = false;
                }
                else if ((((blue[0, 0] + dicePoints > 39 && blue[0, 0] < 40) || (blue[0, 0] == 0 && dicePoints != 6)) && ((blue[1, 0] + dicePoints > 39 && blue[1, 0] < 40) || (blue[1, 0] == 0 && dicePoints != 6)) && ((blue[2, 0] + dicePoints > 39 && blue[2, 0] < 40) || (blue[2, 0] == 0 && dicePoints != 6)) && ((blue[3, 0] + dicePoints > 39 && blue[3, 0] < 40) || (blue[3, 0] == 0 && dicePoints != 6))) && (blue[0, 2] == 0))
                {
                    x = false;
                }
                break;
            case "red":
                if ((red[0, 0] == 0 || red[0, 0] > 85) && (red[1, 0] == 0 || red[1, 0] > 85) && (red[2, 0] == 0 || red[2, 0] > 85) && (red[3, 0] == 0 || red[3, 0] > 85) && dicePoints != 6)
                {
                    x = false;
                }
                else if ((((red[0, 0] + dicePoints > 26 && red[0,0]<27)|| (red[0, 0] == 0 && dicePoints != 6)) && ((red[1, 0] + dicePoints > 26 && red[1, 0] < 27) || (red[1, 0] == 0 && dicePoints != 6)) && ((red[2, 0] + dicePoints > 26 && red[2, 0] < 27) || (red[2, 0] == 0 && dicePoints != 6)) && ((red[3, 0] + dicePoints > 26 && red[3, 0] < 27) || (red[3, 0] == 0 && dicePoints != 6))) && (red[0, 2] == 0))
                {
                    x = false;
                }
                break;
            case "yellow":
                if ((yellow[0, 0] == 0 || yellow[0, 0] > 65) && (yellow[1, 0] == 0 || yellow[1, 0] > 65) && (yellow[2, 0] == 0 || yellow[2, 0] > 65) && (yellow[3, 0] == 0 || yellow[3, 0] > 65) && dicePoints != 6)
                {
                    x = false;
                }
                else if (((yellow[0, 0] + dicePoints > 52 || (yellow[0, 0] == 0 && dicePoints != 6)) && (yellow[1, 0] + dicePoints > 52 || (yellow[1, 0] == 0 && dicePoints != 6)) && (yellow[2, 0] + dicePoints > 52 || (yellow[2, 0] == 0 && dicePoints != 6)) && (yellow[3, 0] + dicePoints > 52 || (yellow[3, 0] == 0 && dicePoints != 6))) && (yellow[0, 2] == 0))
                {
                    x = false;
                }
                break;
                
        }
        return x;
    }

    public static void bringTokenOut(string color, int tokenNum) 
    {
        switch (color)
        {
            case "green":
                green[tokenNum - 1, 0] = 15;
                break;
            case "red":
                red[tokenNum - 1, 0] = 28;
                break;
            case "blue":
                blue[tokenNum - 1, 0] = 41;
                break;
            case "yellow":
                yellow[tokenNum - 1, 0] = 2;
                break;
        }
    }

    public static int throwTokenIn(string thrownBy, int position)
    {
        int thrownNumber = 0;
        switch (thrownBy)
        {
            case "green":
                if (red[0,0] == position && red[0,1]==1)
                {
                    red[0, 0] = 0;
                    thrownNumber = 13;
                    red[0, 1] = 0;
                }
                else if (red[1, 0] == position && red[1, 1] == 1)
                {
                    red[1, 0] = 0;
                    thrownNumber = 14;
                    red[1, 1] = 0;
                }
                else if (red[2, 0] == position && red[2, 1] == 1)
                {
                    red[2, 0] = 0;
                    thrownNumber = 15;
                    red[2, 1] = 0;
                }
                else if (red[3, 0] == position && red[3, 1] == 1)
                {
                    red[3, 0] = 0;
                    thrownNumber = 16;
                    red[3, 1] = 0;
                }

                else if (blue[0, 0] == position && blue[0, 1] == 1)
                        {
                    blue[0, 0] = 0;
                    thrownNumber = 9;
                    blue[0,1] = 0;
                }
                else if (blue[1, 0] == position && blue[1, 1] == 1)
                {
                    blue[1, 0] = 0;
                    thrownNumber = 10;
                    blue[1, 1] = 0;
                }
                else if (blue[2, 0] == position && blue[2, 1] == 1)
                {
                    blue[2, 0] = 0;
                    thrownNumber = 11;
                    blue[2, 1] = 0;
                }
                else if (blue[3, 0] == position && blue[3, 1] == 1)
                {
                    blue[3, 0] = 0;
                    thrownNumber = 12;
                    blue[3, 1] = 0;
                }

                else if (yellow[0, 0] == position && yellow[0, 1] == 1)
                {
                    yellow[0, 0] = 0;
                    thrownNumber = 5;
                    yellow[0, 1] = 0;
                }
                else if (yellow[1, 0] == position && yellow[1, 1] == 1)
                {
                    yellow[1, 0] = 0;
                    thrownNumber = 6;
                    yellow[1, 1] = 0;
                }
                else if (yellow[2, 0] == position && yellow[2, 1] == 1)
                {
                    yellow[2, 0] = 0;
                    thrownNumber = 7;
                    yellow[2, 1] = 0;
                }
                else if (yellow[3, 0] == position && yellow[3, 1] == 1)
                {
                    yellow[3, 0] = 0;
                    thrownNumber = 8;
                    yellow[3, 1] = 0;
                }
                break;
            case "red":
                if (green[0, 0] == position && green[0, 1] == 1)
                {
                    thrownNumber = 1;
                    green[0, 0] = 0;
                    green[0, 1] = 0;
                }
                else if (green[1, 0] == position && green[1, 1] == 1)
                {
                    thrownNumber = 2;
                    green[1, 0] = 0;
                    green[1, 1] = 0;
                }
                else if (green[2, 0] == position && green[2, 1] == 1)
                {
                    thrownNumber = 3;
                    green[2, 0] = 0;
                    green[2, 1] = 0;
                }
                else if (green[3, 0] == position && green[3, 1] == 1)
                {
                    thrownNumber = 4;
                    green[3, 0] = 0;
                    green[3, 1] = 0;
                }
                else if (blue[0, 0] == position && blue[0, 1] == 1)
                {
                    blue[0, 0] = 0;
                    thrownNumber = 9;
                    blue[0, 1] = 0;
                }
                else if (blue[1, 0] == position && blue[1, 1] == 1)
                {
                    blue[1, 0] = 0;
                    thrownNumber = 10;
                    blue[1, 1] = 0;
                }
                else if (blue[2, 0] == position && blue[2, 1] == 1)
                {
                    blue[2, 0] = 0;
                    thrownNumber = 11;
                    blue[2, 1] = 0;
                }
                else if (blue[3, 0] == position && blue[3, 1] == 1)
                {
                    blue[3, 0] = 0;
                    thrownNumber = 12;
                    blue[3, 1] = 0;
                }
                else if (yellow[0, 0] == position && yellow[0, 1] == 1)
                {
                    yellow[0, 0] = 0;
                    thrownNumber = 5;
                    yellow[0, 1] = 0;
                }
                else if (yellow[1, 0] == position && yellow[1, 1] == 1)
                {
                    yellow[1, 0] = 0;
                    thrownNumber = 6;
                    yellow[1, 1] = 0;
                }
                else if (yellow[2, 0] == position && yellow[2, 1] == 1)
                {
                    yellow[2, 0] = 0;
                    thrownNumber = 7;
                    yellow[2, 1] = 0;
                }
                else if (yellow[3, 0] == position && yellow[3, 1] == 1)
                {
                    yellow[3, 0] = 0;
                    thrownNumber = 8;
                    yellow[3, 1] = 0;
                }
                break;
            case "blue":
                if (red[0, 0] == position && red[0, 1] == 1)
                {
                    red[0, 0] = 0;
                    thrownNumber = 13;
                    red[0, 1] = 0;
                }
                else if (red[1, 0] == position && red[1, 1] == 1)
                {
                    red[1, 0] = 0;
                    thrownNumber = 14;
                    red[1, 1] = 0;
                }
                else if (red[2, 0] == position && red[2, 1] == 1)
                {
                    red[2, 0] = 0;
                    thrownNumber = 15;
                    red[2, 1] = 0;
                }
                else if (red[3, 0] == position && red[3, 1] == 1)
                {
                    red[3, 0] = 0;
                    thrownNumber = 16;
                    red[3, 1] = 0;
                }
                else if (green[0, 0] == position && green[0, 1] == 1)
                {
                    thrownNumber = 1;
                    green[0, 0] = 0;
                    green[0, 1] = 0;
                }
                else if (green[1, 0] == position && green[1, 1] == 1)
                {
                    thrownNumber = 2;
                    green[1, 0] = 0;
                    green[1, 1] = 0;
                }
                else if (green[2, 0] == position && green[2, 1] == 1)
                {
                    thrownNumber = 3;
                    green[2, 0] = 0;
                    green[2, 1] = 0;
                }
                else if (green[3, 0] == position && green[3, 1] == 1)
                {
                    thrownNumber = 4;
                    green[3, 0] = 0;
                    green[3, 1] = 0;
                }
                else if (yellow[0, 0] == position && yellow[0, 1] == 1)
                {
                    yellow[0, 0] = 0;
                    thrownNumber = 5;
                    yellow[0, 1] = 0;
                }
                else if (yellow[1, 0] == position && yellow[1, 1] == 1)
                {
                    yellow[1, 0] = 0;
                    thrownNumber = 6;
                    yellow[1, 1] = 0;
                }
                else if (yellow[2, 0] == position && yellow[2, 1] == 1)
                {
                    yellow[2, 0] = 0;
                    thrownNumber = 7;
                    yellow[2, 1] = 0;
                }
                else if (yellow[3, 0] == position && yellow[3, 1] == 1)
                {
                    yellow[3, 0] = 0;
                    thrownNumber = 8;
                    yellow[3, 1] = 0;
                }

                break;
            case "yellow":
                if (red[0, 0] == position && red[0, 1] == 1)
                {
                    red[0, 0] = 0;
                    thrownNumber = 13;
                    red[0, 1] = 0;
                }
                else if (red[1, 0] == position && red[1, 1] == 1)
                {
                    red[1, 0] = 0;
                    thrownNumber = 14;
                    red[1, 1] = 0;
                }
                else if (red[2, 0] == position && red[2, 1] == 1)
                {
                    red[2, 0] = 0;
                    thrownNumber = 15;
                    red[2, 1] = 0;
                }
                else if (red[3, 0] == position && red[3, 1] == 1)
                {
                    red[3, 0] = 0;
                    thrownNumber = 16;
                    red[3, 1] = 0;
                }

                else if (blue[0, 0] == position && blue[0, 1] == 1)
                {
                    blue[0, 0] = 0;
                    thrownNumber = 9;
                    blue[0, 1] = 0;
                }
                else if (blue[1, 0] == position && blue[1, 1] == 1)
                {
                    blue[1, 0] = 0;
                    thrownNumber = 10;
                    blue[1, 1] = 0;
                }
                else if (blue[2, 0] == position && blue[2, 1] == 1)
                {
                    blue[2, 0] = 0;
                    thrownNumber = 11;
                    blue[2, 1] = 0;
                }
                else if (blue[3, 0] == position && blue[3, 1] == 1)
                {
                    blue[3, 0] = 0;
                    thrownNumber = 12;
                    blue[3, 1] = 0;
                }

                else if (green[0, 0] == position && green[0, 1] == 1)
                {
                    thrownNumber = 1;
                    green[0, 0] = 0;
                    green[0, 1] = 0;
                }
                else if (green[1, 0] == position && green[1, 1] == 1)
                {
                    thrownNumber = 2;
                    green[1, 0] = 0;
                    green[1, 1] = 0;
                }
                else if (green[2, 0] == position && green[2, 1] == 1)
                {
                    thrownNumber = 3;
                    green[2, 0] = 0;
                    green[2, 1] = 0;
                }
                else if (green[3, 0] == position && green[3, 1] == 1)
                {
                    thrownNumber = 4;
                    green[3, 0] = 0;
                    green[3, 1] = 0;
                }

                break;
        }
        return thrownNumber;
    }

    public static int moveToken(string color, int tokenNum, int dicePoints)
    {
        int status = 0;
        switch (color)
        {
            case "green":
                if((green[0,0] == 0|| green[0, 0] > 75) &&(green[1, 0] == 0 || green[1, 0] >75) &&(green[2, 0] == 0 || green[2, 0] > 75) &&(green[3, 0] == 0 || green[3, 0] > 75) && dicePoints != 6)
                {
                    status = 1;
                }
                else if (green[tokenNum-1,0] == 0 && dicePoints == 6)
                {
                    bringTokenOut("green",tokenNum);
                    status = 1;
                }
                else if (green[tokenNum - 1, 0]+dicePoints>52 && green[tokenNum - 1, 0]<71)
                {
                    green[tokenNum - 1, 0] = green[tokenNum - 1, 0]+dicePoints - 52;
                    status = 1;
                }
                else if (green[tokenNum - 1, 0] + dicePoints > 13 && green[tokenNum - 1, 0] < 14&& green[tokenNum - 1, 2] == 1)
                {
                    green[tokenNum - 1, 0] = green[tokenNum - 1, 0] + dicePoints + 57;
                    status = 1;
                }
                else if(green[tokenNum - 1, 0] !=0 && (green[tokenNum-1, 0] + dicePoints <= 13 || green[tokenNum-1, 0] > 14 || green[tokenNum-1,0]>60))
                {
                    green[tokenNum - 1, 0] = green[tokenNum - 1, 0] + dicePoints;
                    status = 1;
                }
                if (green[tokenNum - 1, 0] == 2 || green[tokenNum - 1, 0] == 15 || green[tokenNum - 1, 0] == 28 || green[tokenNum - 1, 0] == 41)
                {
                    green[tokenNum - 1, 1] = 0;
                }
                else
                {
                    green[tokenNum - 1, 1] = 1;
                }
                if (green[1,0]>75&&green[0,0]>75&&green[2,0]>75&&green[3,0]>75)
                {
                    positions[pos] = "green";
                    pos++;
                }
                break;
            case "blue":
                if ((blue[0, 0] == 0 || blue[0, 0] > 95) && (blue[1, 0] == 0 || blue[1, 0] > 95) && (blue[2, 0] == 0 || blue[2, 0] > 95) && (blue[3, 0] == 0 || blue[3, 0] > 95) && dicePoints != 6)
                {
                    status = 1;
                }
                else if (blue[tokenNum - 1, 0] == 0 && dicePoints == 6)
                {
                    bringTokenOut("blue", tokenNum);
                    status = 1;
                }
                else if (blue[tokenNum - 1, 0] + dicePoints > 52 && blue[tokenNum - 1, 0] < 91)
                {
                    blue[tokenNum - 1, 0] = blue[tokenNum - 1, 0] + dicePoints - 52;
                    status = 1;
                }
                else if (blue[tokenNum - 1, 0] + dicePoints > 39 && blue[tokenNum - 1, 0] < 40 && blue[tokenNum - 1, 2] == 1)
                {
                    blue[tokenNum - 1, 0] = blue[tokenNum - 1, 0] + dicePoints + 51;
                    status = 1;
                }
                else if (blue[tokenNum - 1, 0] != 0 && (blue[tokenNum - 1, 0] + dicePoints <= 39 || blue[tokenNum - 1, 0] > 40 || blue[tokenNum-1,0]>60))
                {
                    blue[tokenNum - 1, 0] = blue[tokenNum - 1, 0] + dicePoints;
                    status = 1;
                }
                if (blue[tokenNum - 1, 0] == 2 || blue[tokenNum - 1, 0] == 15 || blue[tokenNum - 1, 0] == 28 || blue[tokenNum - 1, 0] == 41)
                {
                    blue[tokenNum - 1, 1] = 0;
                }
                else
                {
                    blue[tokenNum - 1, 1] = 1;
                }
                if (blue[1, 0] > 95 && blue[0, 0] > 95 && blue[2, 0] > 95 && blue[3, 0] > 95)
                {
                    positions[pos] = "blue";
                    pos++;
                }
                break;
            case "red":
                if ((red[0, 0] == 0 || red[0, 0] > 85) && (red[1, 0] == 0 || red[1, 0] > 85) && (red[2, 0] == 0 || red[2, 0] > 85) && (red[3, 0] == 0 || red[3, 0] > 85) && dicePoints != 6)
                {
                    status = 1;
                }
                else if (red[tokenNum - 1, 0] == 0 && dicePoints == 6)
                {
                    bringTokenOut("red", tokenNum);
                    status = 1;
                }
                else if (red[tokenNum - 1, 0] + dicePoints > 52 && red[tokenNum - 1, 0] < 81)
                {
                    red[tokenNum - 1, 0] = red[tokenNum - 1, 0] + dicePoints - 52;
                    status = 1;
                }
                else if (red[tokenNum - 1, 0] + dicePoints > 26 && red[tokenNum - 1, 0] < 27 && red[tokenNum - 1, 2] == 1)
                {
                    red[tokenNum - 1, 0] = red[tokenNum - 1, 0] + dicePoints + 54;
                    status = 1;
                }
                else if(red[tokenNum - 1, 0] != 0 && (red[tokenNum-1, 0] + dicePoints <= 26 || red[tokenNum-1, 0] > 27||red[tokenNum - 1, 0]>60))
                {
                    red[tokenNum - 1, 0] = red[tokenNum - 1, 0] + dicePoints;
                    status = 1;
                }
                if (red[tokenNum - 1, 0] == 2 || red[tokenNum - 1, 0] == 15 || red[tokenNum - 1, 0] == 28 || red[tokenNum - 1, 0] == 41)
                {
                    red[tokenNum - 1, 1] = 0;
                }
                else
                {
                    red[tokenNum - 1, 1] = 1;
                }
                if (red[1, 0] >85 && red[0, 0] > 85 && red[2, 0] > 85 && red[3, 0] > 85)
                {
                    positions[pos] = "red";
                    pos++;
                }
                break;
            case "yellow":
                if ((yellow[0, 0] == 0 || yellow[0, 0] > 65) && (yellow[1, 0] == 0 || yellow[1, 0] > 65) && (yellow[2, 0] == 0 || yellow[2, 0] > 65) && (yellow[3, 0] == 0 || yellow[3, 0] > 65) && dicePoints != 6)
                {
                    status = 1;
                }
                else if (yellow[tokenNum - 1, 0] == 0 && dicePoints == 6)
                {
                    bringTokenOut("yellow", tokenNum);
                    status = 1;
                }
                else if (yellow[tokenNum - 1, 0]+ dicePoints >52 && yellow[tokenNum-1,2]==1)
                {
                    yellow[tokenNum - 1, 0] = yellow[tokenNum - 1, 0] + dicePoints + 8;
                    status = 1;
                }
                else if (yellow[tokenNum - 1, 0] != 0 && (yellow[tokenNum - 1, 0]+dicePoints<=52 || yellow[tokenNum-1,0]>60))
                {
                    yellow[tokenNum - 1, 0] = yellow[tokenNum - 1, 0] + dicePoints;
                    status = 1;
                }
                if (yellow[tokenNum - 1, 0] == 2 || yellow[tokenNum - 1, 0] == 15 || yellow[tokenNum - 1, 0] == 28 || yellow[tokenNum - 1, 0] == 41)
                {
                    yellow[tokenNum - 1, 1] = 0;
                }
                else
                {
                    yellow[tokenNum - 1, 1] = 1;
                }
                if (yellow[1, 0] > 65 && yellow[0, 0] > 65 && yellow[2, 0] > 65 && yellow[3, 0] > 65)
                {
                    positions[pos] = "yellow";
                    pos++;
                }
                break;
        }
        return status;
    }


    public static bool throwDicePermission(string color)
    {
        bool i = true;
        switch (color)
        {
            case "red":
                if ((red[0, 0] > 85) && ( red[1, 0] > 85) && (red[2, 0] > 85) && (red[3, 0] > 85))
                {
                    i = false;
                }
                break;
            case "blue":
                if ((blue[0, 0] > 95) && (blue[1, 0] > 95) && (blue[2, 0] > 95) && (blue[3, 0] > 95))
                {
                    i = false;
                }
                break;
            case "green":
                if ((green[0, 0] > 75) && (green[1, 0] > 75) && (green[2, 0] > 75) && (green[3, 0] > 75))
                {
                    i = false;
                }
                break;
            case "yellow":
                if ((yellow[0, 0] > 65) && (yellow[1, 0] > 65) && (yellow[2, 0] > 65) && (yellow[3, 0] > 65))
                {
                    i = false;
                }
                break;
        }
        return i;
    }

    public static void afterThrowChangeStatus(string color)
    {
        switch (color)
        {
            case "red":
                red[0,2] = 1;
                red[1, 2] = 1;
                red[2, 2] = 1;
                red[3, 2] = 1;
                break;
            case "blue":
                blue[0, 2] = 1;
                blue[1, 2] = 1;
                blue[2, 2] = 1;
                blue[3, 2] = 1;
                break;
            case "green":
                green[0, 2] = 1;
                green[1, 2] = 1;
                green[2, 2] = 1;
                green[3, 2] = 1;
                break;
            case "yellow":
                yellow[0, 2] = 1;
                yellow[1, 2] = 1;
                yellow[2, 2] = 1;
                yellow[3, 2] = 1;
                break;
        }
    }
    public static int xPosition(string color, int tokenNum)
    {
        int x = 0;
        int p=0;
        switch (color)
        {
            case "red":
                p = red[tokenNum -1,0];
                break;
            case "blue":
                p = blue[tokenNum - 1, 0];
                break;
            case "green":
                p = green[tokenNum - 1, 0];
                break;
            case "yellow":
                p = yellow[tokenNum - 1, 0];
                break;
        }
        switch (p)
        {
            case 0:
                switch (color)
                {
                    case "red":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 321;
                                break;
                            case 2:
                                x = 293;
                                break;
                            case 3:
                                x = 347;
                                break;
                            case 4:
                                x = 321;
                                break;
                        }
                        break;
                    case "blue":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 321;
                                break;
                            case 2:
                                x = 293;
                                break;
                            case 3:
                                x = 347;
                                break;
                            case 4:
                                x = 321;
                                break;
                        }
                        break;
                    case "green":
                        switch (tokenNum)
                        {
                            case 1:
                                
                                x = 80;
                                break;
                            case 2:
                                x = 54;
                                break;
                            case 3:
                                x = 108;
                                break;
                            case 4:
                                x = 80;
                                break;
                        }
                        break;
                    case "yellow":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 80;
                                break;
                            case 2:
                                x = 54;
                                break;
                            case 3:
                                x = 108;
                                break;
                            case 4:
                                x = 80;
                                break;
                        }
                        break;
                }
                break;
            case 1:
                x = 174;
                break;
            case 2:
                x = 174;
                break;
            case 3:
                x = 174;
                break;
            case 4:
                x = 174;
                break;
            case 5:
                x = 174;
                break;
            case 6:
                x = 174;
                break;
            case 7:
                x = 148;
                break;
            case 8:
                x = 121;
                break;
            case 9:
                x = 95;
                break;
            case 10:
                x = 67;
                break;
            case 11:
                x = 41;
                break;
            case 12:
                x = 14;
                break;
            case 13:
                x = 14;
                break;
            case 14:
                x = 14;
                break;
            case 15:
                x = 41;
                break;
            case 16:
                x = 67;
                break;
            case 17:
                x = 95;
                break;
            case 18:
                x = 121;
                break;
            case 19:
                x = 148;
                break;
            case 20:
                x = 174;
                break;
            case 21:
                x = 174;
                break;
            case 22:
                x = 174;
                break;
            case 23:
                x = 174;
                break;
            case 24:
                x = 174;
                break;
            case 25:
                x = 174;
                break;
            case 26:
                x = 201;
                break;
            case 27:
                x = 228;
                break;
            case 28:
                x = 228;
                break;
            case 29:
                x = 228;
                break;
            case 30:
                x = 228;
                break;
            case 31:
                x = 228;
                break;
            case 32:
                x = 228;
                break;
            case 33:
                x = 253;
                break;
            case 34:
                x = 280;
                break;
            case 35:
                x = 306;
                break;
            case 36:
                x = 334;
                break;
            case 37:
                x = 361;
                break;
            case 38:
                x = 382;
                break;
            case 39:
                x = 382;
                break;
            case 40:
                x = 382;
                break;
            case 41:
                x = 361;
                break;
            case 42:
                x = 334;
                break;
            case 43:
                x = 306;
                break;
            case 44:
                x = 280;
                break;
            case 45:
                x = 253;
                break;
            case 46:
                x = 228;
                break;
            case 47:
                x = 228;
                break;
            case 48:
                x = 228;
                break;
            case 49:
                x = 228;
                break;
            case 50:
                x = 228;
                break;
            case 51:
                x = 228;
                break;
            case 52:
                x = 201;
                break;
            case 61:
                x = 201;
                break;
            case 62:
                x = 201;
                break;
            case 63:
                x = 201;
                break;
            case 64:
                x = 201;
                break;
            case 65:
                x = 201;
                break;
            case 71:
                x = 41;
                break;
            case 72:
                x = 67;
                break;
            case 73:
                x = 95;
                break;
            case 74:
                x = 121;
                break;
            case 75:
                x = 148;
                break;
            case 81:
                x = 201;
                break;
            case 82:
                x = 201;
                break;
            case 83:
                x = 201;
                break;
            case 84:
                x = 201;
                break;
            case 85:
                x = 201;
                break;
            case 91:
                x = 361;
                break;
            case 92:
                x = 334;
                break;
            case 93:
                x = 306;
                break;
            case 94:
                x = 280;
                break;
            case 95:
                x = 253;
                break;
        }
        return x;
    }

    public static int yPosition(string color, int tokenNum)
    {
        int x = 0;
        int p = 0;
        switch (color)
        {
            case "red":
                p = red[tokenNum - 1, 0];
                break;
            case "blue":
                p = blue[tokenNum - 1, 0];
                break;
            case "green":
                p = green[tokenNum - 1, 0];
                break;
            case "yellow":
                p = yellow[tokenNum - 1, 0];
                break;
        }
        switch (p)
        {
            case 0:
                switch (color)
                {
                    case "red":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 53;
                                break;
                            case 2:
                                x = 80;
                                break;
                            case 3:
                                x = 80;
                                break;
                            case 4:
                                x = 106;
                                break;
                        }
                        break;
                    case "blue":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 293;
                                break;
                            case 2:
                                x = 320;
                                break;
                            case 3:
                                x = 320;
                                break;
                            case 4:
                                x = 346;
                                break;
                        }
                        break;
                    case "green":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 53;
                                break;
                            case 2:
                                x = 80;
                                break;
                            case 3:
                                x = 80;
                                break;
                            case 4:
                                x = 106;
                                break;
                        }
                        break;
                    case "yellow":
                        switch (tokenNum)
                        {
                            case 1:
                                x = 293;
                                break;
                            case 2:
                                x = 320;
                                break;
                            case 3:
                                x = 320;
                                break;
                            case 4:
                                x = 346;
                                break;
                        }
                        break;
                }
                break;
            case 1:
                x = 386;
                break;
            case 2:
                x = 360;
                break;
            case 3:
                x = 333;
                break;
            case 4:
                x = 306;
                break;
            case 5:
                x = 280;
                break;
            case 6:
                x = 253;
                break;
            case 7:
                x = 227;
                break;
            case 8:
                x = 227;
                break;
            case 9:
                x = 227;
                break;
            case 10:
                x = 227;
                break;
            case 11:
                x = 227;
                break;
            case 12:
                x = 227;
                break;
            case 13:
                x = 200;
                break;
            case 14:
                x = 173;
                break;
            case 15:
                x = 173;
                break;
            case 16:
                x = 173;
                break;
            case 17:
                x = 173;
                break;
            case 18:
                x = 173;
                break;
            case 19:
                x = 173;
                break;
            case 20:
                x = 147;
                break;
            case 21:
                x = 121;
                break;
            case 22:
                x = 94;
                break;
            case 23:
                x = 67;
                break;
            case 24:
                x = 40;
                break;
            case 25:
                x = 13;
                break;
            case 26:
                x = 13;
                break;
            case 27:
                x = 13;
                break;
            case 28:
                x = 40;
                break;
            case 29:
                x = 67;
                break;
            case 30:
                x = 94;
                break;
            case 31:
                x = 121;
                break;
            case 32:
                x = 147;
                break;
            case 33:
                x = 173;
                break;
            case 34:
                x = 173;
                break;
            case 35:
                x = 173;
                break;
            case 36:
                x = 173;
                break;
            case 37:
                x = 173;
                break;
            case 38:
                x = 173;
                break;
            case 39:
                x = 200;
                break;
            case 40:
                x = 227;
                break;
            case 41:
                x = 227;
                break;
            case 42:
                x = 227;
                break;
            case 43:
                x = 227;
                break;
            case 44:
                x = 227;
                break;
            case 45:
                x = 227;
                break;
            case 46:
                x = 253;
                break;
            case 47:
                x = 280;
                break;
            case 48:
                x = 306;
                break;
            case 49:
                x = 333;
                break;
            case 50:
                x = 360;
                break;
            case 51:
                x = 386;
                break;
            case 52:
                x = 386;
                break;
            case 61:
                x = 360;
                break;
            case 62:
                x = 333;
                break;
            case 63:
                x = 306;
                break;
            case 64:
                x = 280;
                break;
            case 65:
                x = 253;
                break;
            case 71:
                x = 200;
                break;
            case 72:
                x = 200;
                break;
            case 73:
                x = 200;
                break;
            case 74:
                x = 200;
                break;
            case 75:
                x = 200;
                break;
            case 81:
                x = 40;
                break;
            case 82:
                x = 67;
                break;
            case 83:
                x = 94;
                break;
            case 84:
                x = 121;
                break;
            case 85:
                x = 147;
                break;
            case 91:
                x = 200;
                break;
            case 92:
                x = 200;
                break;
            case 93:
                x = 200;
                break;
            case 94:
                x = 200;
                break;
            case 95:
                x = 200;
                break;
        }
        return x;

    }
}
