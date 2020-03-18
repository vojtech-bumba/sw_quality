namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point = 0;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string ChooseScore(int score)
        {
            switch (score)
            {
                case 0: return "Love";
                case 1: return "Fifteen";
                case 2: return "Thirty";
                case 3: return "Forty";
                default: return ""; // I would throw an exception here but that would be changing the logic
            }
        }

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point)
            {
                if (p1point == 0)
                    score = "Love";
                if (p1point == 1)
                    score = "Fifteen";
                if (p1point == 2)
                    score = "Thirty";
                return score.Length > 0 ? $"{score}-All" : "Deuce";
            }

            if (p1point < 4  || p2point < 4)
            {
                p1res = ChooseScore(p1point);
                p2res = ChooseScore(p2point);
                score = $"{p1res}-{p2res}";
            }

            if (p1point >=3 && p2point >=3)
            {
                score = p1point > p2point ? $"Advantage {player1Name}" : $"Advantage {player2Name}";
            }

            if ((p1point >= 4 || p2point >= 4) && (p1point - p2point >= 2 || p2point - p1point >= 2)) {
                return p1point > p2point ? $"Win for {player1Name}" : $"Win for {player2Name}";
            }

            return score;
        }

        public void SetP1Score(int number)
        {
            p1point += number;
        }

        public void SetP2Score(int number)
        {
            p2point += number;
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                p1point++;
            if (player == player2Name)
                p2point++;
        }

    }
}

