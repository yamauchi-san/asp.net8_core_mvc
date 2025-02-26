using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// HelloWorldコントローラ

namespace MvcMovie.Controllers;

// コントローラークラス
public class HelloWorldController : Controller
{
    // アクションメソッド(関数)

    // URLパス~/HelloWorld
    // GET: /HelloWorld/
    //public string Index()
    //{
    //    return "This is my default action...";
    //}

    // View
    public IActionResult Index()
    {
        // ビューテンプレートを使って.cshtmlファイルに表示させる場合
        ViewData["Comment"] = "comment";
        
        // Viewメソッドを使って_Layout.cshtmlと対象.cshtmlファイルの内容を表示する
        return View();
    }

    // URLパス~/HelloWorld/Welcome
    // GET: /HelloWorld/Welcome/ 
    //public string Welcome()
    //{
    //    return "This is the Welcome action method...";
    //}

    // URLパス~/HelloWorld/Welcome?name=...&numTime=...となる
    //public string Welcome(string name="dosukoi", int numTime = 1)
    //{
    //    // JavaScript などによる悪意のある入力からアプリを保護するクラス・メソッド
    //    return HtmlEncoder.Default.Encode($"{name}, Nnmtime is: {numTime}");
    //}

    // app.MapControllerRouteのidと一致するので
    // URLパス~/HelloWorld/Welcome/?(数字)&name=...となる
    // また、URLパス~/HelloWorld/Welcome?name=...&id=...でもOK
    //public string Welcome(string name = "dosukoi", int ID = 1)
    //{
    //    // JavaScript などによる悪意のある入力からアプリを保護するクラス・メソッド
    //    return HtmlEncoder.Default.Encode($"{name}, ID is: {ID}");
    //}

    //　プレースホルダをを設定して戻り値でView関数実行
    public IActionResult Welcome(string name, int numtimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["Numtimes"] = numtimes;
        return View();
    }

    // URLパス~/HelloWorld/Extra/...(idを入れる)?&name=...&sid=...となる
    // 又は、URLパス~/HelloWorld/Extra?id=...&name=...&sid=...となる
    public string Extra(int id, string name, int sid)
    {
        return $"組合番号{id}、名前は{name}、所属グループは{sid}";
    }
}