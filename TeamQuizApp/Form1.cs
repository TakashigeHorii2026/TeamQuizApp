namespace TeamQuizApp
{
    public partial class Form1 : Form
    {
        private readonly QuestionLoader loader;
        private readonly AnswerChecker checker;
        private readonly ScoreManager score;
        private readonly UiUpdater ui;

        private Question current;

        public Form1()
        {
            InitializeComponent();

            loader = new QuestionLoader();
            checker = new AnswerChecker();
            score = new ScoreManager();
            ui = new UiUpdater(label1,
                new[] { button1, button2, button3, button4 },
                listBox1);

            LoadNextQuestion();
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            int index = Array.IndexOf(new[] { button1, button2, button3, button4 }, btn);

            bool result = checker.CheckAnswer(current, index);
            score.Record(result);

            ui.LogResult(result ? "正解！" : "不正解...");
            ui.LogResult(score.GetResult());

            LoadNextQuestion();
        }

        private void LoadNextQuestion()
        {
            current = loader.GetRandomQuestion();
            ui.ShowQuestion(current);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //answerButton_Click(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //answerButton_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // answerButton_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // answerButton_Click(sender, e);
        }
    }
}
