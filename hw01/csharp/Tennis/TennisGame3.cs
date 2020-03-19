namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2;
        private int player1;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score;
            if ((player1 < 4 && player2 < 4) && (player1 + player2 < 6))
            {
                string[] possible = { "Love", "Fifteen", "Thirty", "Forty" };
                score = possible[player1];
                return (player1 == player2) ? $"{score}-All" : $"{score}-{possible[player2]}";
            }
            else
            {
                if (player1 == player2)
                    return "Deuce";
                score = player1 > player2 ? player1Name : player2Name;
                return ((player1 - player2) * (player1 - player2) == 1) ? $"Advantage {score}" : $"Win for {score}";
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                this.player1++;
            if (playerName == player2Name)
                this.player2++;
        }

    }
}

