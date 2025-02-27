using System.ComponentModel.DataAnnotations;
// DBのカラムの設定はこちらで行う
// MvcMovieプロジェクトのModelsディレクトリ

// 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models;

// Movieクラス
public class Movie
{
    // id
    public int Id { get; set; }
    // タイトル
    public string? Title { get; set; }
    // Display属性を使ってブラウザでの表示を変更
    [Display(Name = "Release Date")]
    // HTML フォームの type="date" に変換し、カレンダー UI を有効化
    [DataType(DataType.Date)]
    // ユーザーは日付フィールドに時刻の情報を入力する必要はない
    // 日付のみが表示され、時刻の情報は表示されません
    public DateTime ReleaseDate { get; set; }
    // 
    public string? Genre { get; set; }
    // Entity Framework Core がデータベースの通貨と Price を正しくマッピングできるようにする
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // 新しいフィールド評価を示すRatingを追加
    public string? Rating { get; set; }
}