# Inventory System for Multiple Stores

This is a simple console-based inventory system built using C#. It allows you to add items (such as shoes and clothes) to multiple stores and calculates the total price and quantity of the items in each store.

## Features

- **Add items to stores**: You can add multiple items to a store, such as shoes and clothes.
- **Calculate total price and quantity**: The system calculates the total price and total quantity of the items in each store.
- **Display store inventory**: The system lists all items in each store, along with their individual prices, quantities, and types.

## Technologies Used

- C# (.NET 8 or later)
- Console Application

## How to Use

1. Clone this repository:

   ```bash
   git clone https://github.com/tkarombang/C--Beginerrs

2. Example Output:

![the result](./assets/result.png)

3. Code Explanation
The project defines two main store type: TokoMedia and Barang, with derived classes fo specific items such as Sepatu (shoe) and Baju (clothes).
#### Key Classes:
- TokoMedia: Represents a store that contains a list of items.
- Barang: Abstract class for items with basic attributes like Nama, jenisBarang(), totHargaBarang(), and totBarang().
- Sepatu and Baju: Classes derived from Barang to define specific types of items (shoe and clothes).

#### Calculation Logic:
- Total Price: Calculated by multiplying the price and quantity of each item.
- Total Quantity: Summed up for each store.

#### Adding Items to a Store
To add new items to a store, you can modify the code in the following way:
```cs
//TOKO 1
tSepatu.Barangs.Add(new Sepatu("Adidas", 150, 3));
tSepatu.Barangs.Add(new Sepatu("Ortuseight", 120, 6));

//TOKO 2
tBaju.Barangs.Add(new Baju("erspo", 300, 10));
```
#### Running the Application
Once the items are added, the system will wutomatically display the total price and quantity for each store.


4. Reading The Code
#### Creating Class TokoMedia
```cs
public class TokoMedia(string namabarang)
{
    public string Nama { get; } = namabarang;
    public List<Barang> Barangs { get; } = new();

    public override string ToString()
    {
        return $"Toko {Nama}";
    }
```
- This class represent a store that contains a list of item Barang and nama ( Nama )
- ToString() method will return a string such as "Toko Haji_Sports" or "Toko sportStation" when the object is printed
- in this code there is a new() type, new() is used to create a new object of type "List<Barang>". Since the type "List<Barang>" is already known from the property definition, you don't need t write "new List<Barang>()" in full. "new()" is sufficient to initialize an empty list.
- { get;} is a way to define a property in C#. Properties are used to access data(fields) from an object safely, usually using a getter (to read data) and a setter (to modify data).
now we need the shoe and clothes class

```cs
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
```
#### Sepatu & Baju Class
- this class is a subclass of Barang, representing shoes and baju.
- totHargaBarang() calculates the total price by multiplying the unit price by the quantity.
- jenisBarang() returns the type of Barang as "Sneekers" or "Jersey".
- totBarang() returns the number of shoes or clothes.

#### Create the Object
```cs
var tSepatu = new TokoMedia("Haji_Sports");
var tBaju = new TokoMedia("sportStation");
```
- Two TokoMedia objects are initialized: one for "Haji_Sports"(a shoe store) and one for "sportStation"(a clothing store).
- when you create an object you need a keyword "new". The keyword used to define a class or an object.

#### Class Barang (Abstract)
```cs
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
```
- Barang is an abstract class that provides a framework for items sold in a store
- The methods "jenisBarang()", "totHargaBarang()", and "totBarang()" must be implemented in derived classes
- the "ToString()" method will display the details of the item, including type, total price, and quantity.
 

### Abstract & Override in method 
- The same general function, but when faced with a specific object, it will have a specific function as well, this is called OVERRIDING.
- for vehicles with a general concept, this is called ABSTRACT because you can't directly say how a vehicle moves or stops without mentioning the specific vehicle.
Illustrate of Abstract:
Imagine we have a vehicle that can move and stop. However, since each vehicle has a unique way of moving and stopping, we can't immediately explain how it works. This is called abstraction--the general concept exists, but we can't determine the specifics without knowing the particular type of vehicle.
Illustrate of Override:
For example, my younger sibling has a motorcycle. This motorcycle can move with wheels and stop with brakes. When we define how the motorcycle moves and stops, we are doing overriding. This means we take the general functions of moving and stopping from the parent class of vehicles, but we replace how they work with an implementation that is suitable for motorcycles.


#### Save Toko in a List and use "foreach"
```cs

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
```
- A store list is created to hold two stores (tSepatu and tBaju)
- Using foreach, each store is processed to calculate the total price and total quantity of items.
- Each store is displayed along with the total price and quantity of items
- At the end, the number of stores (toko.Count) is displayed 



### Conclusion
This demonstrates the use of object-oriented principles in C#, specifically focusing on concepts of abstration and method overriding. By using an abstract base class to defene common behaviors and allowing derived classes to provide specific implementations, we can create flexible and reusable code. The TokoMedia class and its items (such as Sepatu and Baju) showcase how we can structure data effectively while applying these concepts. Feel free to extend this examp by adding more store types and products to see how abstraction and overriding can be applied in various scenarios.

Thank you for checking out my job! Contribution, suggestions, and feedback are always welcome.