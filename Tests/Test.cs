using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Language;
using System.Threading.Tasks;

namespace Tests;

public class Test
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(null)]
    [TestCase("")]
    public void String_例外値(string text)
    {
        var data1 = Ngram.ParseToString("", Size.Uni);
        var data2 = Ngram.ParseToString("", Size.Bi);
        var data3 = Ngram.ParseToString("", Size.Tri);
        var data4 = Ngram.ParseToString("", Size.n4);
        var data5 = Ngram.ParseToString("", Size.n5);

        Assert.AreEqual(0, data1.Count());
        Assert.AreEqual(0, data2.Count());
        Assert.AreEqual(0, data3.Count());
        Assert.AreEqual(0, data4.Count());
        Assert.AreEqual(0, data5.Count());
    }


    [TestCase(null)]
    [TestCase("")]
    public void Char_例外値(string text)
    {
        var data1 = Ngram.ParseToCharArray("", Size.Uni);
        var data2 = Ngram.ParseToCharArray("", Size.Bi);
        var data3 = Ngram.ParseToCharArray("", Size.Tri);
        var data4 = Ngram.ParseToCharArray("", Size.n4);
        var data5 = Ngram.ParseToCharArray("", Size.n5);

        Assert.AreEqual(0, data1.Count());
        Assert.AreEqual(0, data2.Count());
        Assert.AreEqual(0, data3.Count());
        Assert.AreEqual(0, data4.Count());
        Assert.AreEqual(0, data5.Count());
    }

    [TestCase("あ")]
    [TestCase("あい")]
    public void String_満たない文字数(string text)
    {
        var data = Ngram.ParseToString(text, Size.Tri);

        foreach (var d in data)
        {
            Assert.AreEqual(text, d);
        }
    }

    [TestCase("あ")]
    [TestCase("あい")]
    public void Char_満たない文字数(string text)
    {
        var data = Ngram.ParseToCharArray(text, Size.Tri);

        foreach (var d in data)
        {
            var sample = new char[(int)Size.Tri];

            Array.Copy(text.ToCharArray(), 0, sample, 0, text.Length);
            Assert.AreEqual(sample, d);
        }
    }

    [TestCase("he is genius", "he is genius", 1)]
    [TestCase("he is genius", "I can fly", 0)]
    [TestCase("he is genius", "she is cute", 0.266667)]
    [TestCase("he is genius", "he is very genius", 0.5625)]
    public void 類似度のサンプル比較(string text1, string text2, double result)
    {
        // 類似度のサンプル元 https://github.com/milk1000cc/trigram
        var answer = Ngram.Compare(text1, text2, Size.Tri);

        Assert.AreEqual(result, answer, 0.0001);
    }

    [TestCase("", "")]
    [TestCase("he is genius", "he is genius")]
    [TestCase("he is genius", "I can fly")]
    [TestCase("he is genius", "she is cute")]
    [TestCase("he is genius", "he is very genius")]
    public void 入れ替え比較(string text1, string text2)
    {
        var answer1 = Ngram.Compare(text1, text2);
        var answer2 = Ngram.Compare(text2, text1);

        Assert.AreEqual(answer1, answer2);
    }
}
