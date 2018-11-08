namespace SpeedGame.Data
{
    public class BSControl
    {
        private int n = 1;
        private int level = 1;
        private float time = 0; // 카운트 증가

        private static BSControl Instance = new BSControl();
        private BSControl(){}

        public static BSControl getInstance()
        {
            return Instance;
        }

        public int N { get => n; set => n = value; }
        public int Level { get => level; set => level = value; }
        public float Time { get => time; set => time = value; }
    }
}