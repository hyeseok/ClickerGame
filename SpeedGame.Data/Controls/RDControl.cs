using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace SpeedGame.Data
{
    public static class RDControl
    {
        //랜덤 숫자 반환
        public static int[] Random_Load(bool triger) 
        {
            int add = 0;
            if (triger)
                add =9;

            bool isFirst = true;
            int idx, old;
            Random random = new Random((int)DateTime.Now.Ticks);
            int[] list = Enumerable.Range(1+add, 9+add).ToArray();

            for (int i = 0; i < 9; i++)
            {
                idx = random.Next(9);
                old = list[i];
                list[i] = list[idx];
                list[idx] = old;
            }
            return list;
        }
    }
}