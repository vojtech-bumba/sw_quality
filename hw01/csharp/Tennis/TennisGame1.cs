namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        // order matters
        private string[] SCORES = new string[] { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            // this might be considered "changing logic" but the previous one 
            // was simply wrong, so I felt responsible for correcting it
            // same in TennisGame2 and TennisGame3
            // I added a test to this
            if (playerName == this.player1Name)
                m_score1 += 1;
            if (playerName == this.player2Name)
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return m_score1 < 3 ? $"{SCORES[m_score1]}-All" : "Deuce";
            }

            if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) return "Advantage player1";
                if (minusResult == -1) return "Advantage player2";
                if (minusResult >= 2) return "Win for player1";
                return "Win for player2";
            }

            return $"{SCORES[m_score1]}-{SCORES[m_score2]}";
        }
    }
}

