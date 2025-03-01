using System;
using System.ComponentModel.DataAnnotations;
// DBのカラムの設定はこちらで行う
// MvcMovieプロジェクトのModelsディレクトリ

// 
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models;

// Movieクラス
public class Movie
{
    // id
    public int Id { get; set; }
    // タイトル
    // バリデーション(必須、文字数制限)
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    // Display属性を使ってブラウザでの表示を変更
    [Display(Name = "Release Date")]
    // HTML フォームの type="date" に変換し、カレンダー UI を有効化
    [DataType(DataType.Date)]
    // ユーザーは日付フィールドに時刻の情報を入力する必要はない
    // 日付のみが表示され、時刻の情報は表示されません
    // バリデーションは[DataType(DataType.Date)]で必須となる
    public DateTime ReleaseDate { get; set; }
    // ジャンル
    // バリデーション(必須、文字数制限、正規表現で大文字小文字のみ受け付ける)
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }
    // Entity Framework Core がデータベースの通貨と Price を正しくマッピングできるようにする
    // バリデーション(範囲、日時の書式指定)
    [Range(1, 100000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // 新しいフィールド評価を示すRatingを追加
    // バリデーション(必須、文字数制限、正規表現で大文字小文字半角数字を受け付ける)
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string? Rating { get; set; }
}