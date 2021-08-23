using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    class gametools 
    {
       public static int Position()
        {
            for (int i = 0; i < 64; i++)
                if (Cases[i].Image == player.Image)
                    return i;

            return -1;
        }
    }
}
