using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MasterMoney.GameLogic
{
    public class Match
    {
        public Match() 
        {
            Sets = 0;
            isWin = false;
            winGame = 0;
            loseSet = 0;
        }
        public Match(int sets, int winGame, int loseSet) 
        {
            Sets = sets;
            this.winGame = winGame;
            this.loseSet = loseSet;
        }
        public virtual int matchMoney()
        {
            if (isWin)
            {
                return winGame;
            }
            else
            {
                return sets * loseSet;
            }
        }
        public bool isWin { get; set; }
        protected int sets;
        protected int winGame, loseSet;
        public int Sets
        {
            set
            {
                if (value < 0 && value > 4) 
                {
                    sets = 0;
                }
                else
                {
                    sets = value;
                }

                if (sets == 4)
                {
                    this.isWin = true;
                }
                else
                {
                    this.isWin = false;
                }
            }
            get
            {
                return sets;
            }
        }

    }

     class FinalMatch : Match 
    {
        bool isFinal;
        int thirdPlaceWinGame, thirdPlaceLoseSet;
        public FinalMatch(int sets, Match semifinalMatch, int thirdPlaceWinGame, int thirdPlaceLoseSet, int winGame, int loseSet) : base(sets, winGame, loseSet)
        { 
            if (semifinalMatch.isWin)
            {
                this.isFinal = true;
            }
            else
            {
                this.isFinal = false;
            }
            this.thirdPlaceLoseSet = thirdPlaceLoseSet;
            this.thirdPlaceWinGame = thirdPlaceWinGame;
        }
        public override int matchMoney()
        {
            if (isFinal)
            {
                return base.matchMoney();
            }
            else
            {
                if (isWin)
                {
                    return thirdPlaceWinGame;
                }
                else
                {
                    return sets * thirdPlaceLoseSet;
                }
            }
        }
    }
}
