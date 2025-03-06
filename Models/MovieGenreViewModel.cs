using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models;

public class MovieGenreViewModel
{
    // フィルタリングされた映画リスト
    public List<Movie>? Movies { get; set; }
    // ドロップダウンリスト用のジャンルデータ 
    public SelectList? Genres { get; set; }
    // 選択されたジャンル 
    public string? MovieGenre { get; set; }
    // フォームの検索文字列 
    public string? SearchString { get; set; }
}