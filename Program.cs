//using System;

//class Program
//{
//    static void Main()
//    {
//        int barang_A = 10000;
//        int barang_B = 20000;

//        int iptJumBar_A = 2;
//        int iptJumBar_B = 4;

//        int totBarang_A = barang_A * iptJumBar_A;
//        int totBarang_B = barang_B * iptJumBar_B;
//        int total = totBarang_A + totBarang_B;
//        Console.WriteLine($"Jumlah harga barang A: Rp{totBarang_A}");
//        Console.WriteLine($"Jumlah harga barang B: Rp{totBarang_B}");
//        Console.WriteLine($"Total Keseluruhan harga barang: Rp{total}");
//    }
//}


using System.Diagnostics;

Console.WriteLine("Hello Mr.X yang memiliki toko");


var tSepatu = new TokoMedia("Haji_Sports");
var tBaju = new TokoMedia("sportStation");

//TOKO 1
tSepatu.Barangs.Add(new Sepatu("Adidas", 150, 3));
tSepatu.Barangs.Add(new Sepatu("Ortuseight", 120, 6));

//TOKO 2
tBaju.Barangs.Add(new Baju("erspo", 300, 10));

List<TokoMedia> toko = [tSepatu, tBaju];

int totalHargaSemuaBarang = 0;
int totalJumlahSemuaBarang = 0;

foreach(var store in toko)
{
    Console.WriteLine($"{store}");
    int totalHargaPerToko = 0;
    int totalJumlahPerToko = 0;
    foreach(var item in store.Barangs)
    {
        Console.WriteLine($"     {item}");

        totalHargaPerToko += item.totHargaBarang();
        totalJumlahPerToko += item.totBarang();
        totalHargaSemuaBarang += item.totHargaBarang();
        totalJumlahSemuaBarang += item.totBarang();
    }
    Console.WriteLine($"TOTAL HARGA TOKO {store.Nama}: {totalHargaPerToko}");
    Console.WriteLine($"TOTAL JUMLAH BARANG {store.Nama}: {totalJumlahPerToko}\n");

}

Console.WriteLine(totalHargaSemuaBarang);
Console.WriteLine(totalHargaSemuaBarang);
Console.WriteLine($"Total TOKO {toko.Count}");


//AFTER REFACTORING atau bisa disebut PRIMARY CONSTRUCTOR a new fitur di C#
public class TokoMedia(string namabarang)
{
    public string Nama { get; } = namabarang;
    public List<Barang> Barangs { get; } = new();

    public override string ToString()
    {
        return $"Toko {Nama}";
    }

}

public abstract class Barang(string namaBarang)
{
    public string Nama { get; } = namaBarang;
    public abstract string jenisBarang();
    public abstract int totHargaBarang();
    public abstract int totBarang();

    public override string ToString()
    {
        return $"{GetType().Name} DENGAN BRAND {Nama} BERJENIS {jenisBarang()} TOTAL HARGA {totHargaBarang()} SETIAP BRAND {Nama} BERJUMLAH {totBarang()}";

    }

}

public class Sepatu(String namaSepatu, int hargaSepatu, int jumlahSepatu) : Barang(namaSepatu)
{

    public int Price { get; } = hargaSepatu;
    public int Quantity { get; } = jumlahSepatu;
    public override int totHargaBarang() => Price * Quantity;
    public override string jenisBarang() => "Sneekers";
    public override int totBarang() => Quantity;
}

public class Baju(String namaBaju, int hargaBaju, int jumlahBaju) : Barang(namaBaju)
{
    public int Price { get; } = hargaBaju;
    public int Quantity { get; } = jumlahBaju;
    public override int totHargaBarang() => Price * Quantity;
    public override string jenisBarang() => "Jersey";
    public override int totBarang() => Quantity;

}

////BEFORE REFACTORING
//public class TokoMedia
//{
//    //Constructor
//    public TokoMedia(string nama)
//    {
//        namabarang = nama;
//    }
//    private string namabarang;

//}