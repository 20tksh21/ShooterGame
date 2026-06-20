using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalScore = 0;   //①とりあえずフィールドで作る　②外部から取得したくなった→自動実装プロパティ　③間に処理入れたくなった→手動でプロパティ書く
    public int TotalScore
    {
        get { return totalScore; }
        private set { totalScore = value; }
    }
    private const int MAXLEVEL = 10;
    private int levelUpScore = 5;
    private int currentScore = 0;    // 現在のレベル内で溜まったスコア（requiredScoreの計算用）
    private int currentLevel = 0;

    [SerializeField] private TextMeshProUGUI TotalScoreText;
    [SerializeField] private TextMeshProUGUI LevelText;


    public static GameManager Instance { get; private set; }        //シングルトン（このインスタンス以外作らない）


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    //与えたダメージ分スコアに加算する
    public void AddScore(int damage)        
    {
        totalScore += damage;       //クラス内だからプロパティ介さず直接書き換える（処理節約になる）
        currentScore += damage;


        while (currentScore >= levelUpScore && currentLevel < MAXLEVEL)
        {
            currentScore -= levelUpScore; // 溢れた分のスコアを次に持ち越す
            LevelUp();
        }

        UpdateUI();     //すべての計算が終わった後、1回だけ呼ぶ
    }

    private void LevelUp()
    {
        if(currentLevel < MAXLEVEL)
        {
            currentLevel += 1;
            levelUpScore *= 2;
        }
    }

    //UI更新を一つのメソッドにまとめておけば、最後に1回呼び出すだけで済む
    private void UpdateUI()
    {
        if (TotalScoreText != null)
        {
            TotalScoreText.text = $"合計スコア：{TotalScore}";
        }

        if (LevelText != null)
        {
            int requiredScore = levelUpScore - currentScore;
            LevelText.text = $"現在のレベル：{currentLevel}  次のレベルまで：{requiredScore}";
        }
    }
}
