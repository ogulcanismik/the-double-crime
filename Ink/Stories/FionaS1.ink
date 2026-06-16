// --- FIONA V: BOMBA ---

-> fiona_basamak_1

=== fiona_basamak_1 === 
#fallback:fiona_fallback
Bu gemi batmıyor olabilir ama içindeki insanlar çoktan su almaya başlamış. Sence de öyle değil mi tatlım?

* [  Balo hakkında neler düşünüyorsun?]
    Güzel ama herkes fazla gergin tatlım. Arthur’un bastonunu yere her vuruşunda birileri titriyor, fark etmedin mi?
    -> fiona_basamak_2
* [  Masken oldukça dikkat çekici.]
    En azından benimki sahte değil. Bastian’ın geçen ay sattığı o "orijinal" tablolar gibi...
    -> fiona_basamak_2

=== fiona_basamak_2 ===
* [  Arthur Kane ile çok samimi görünüyorsunuz.]
    Ah, Arthur... Eski bir dost diyelim. Ama dostluklar bazen borçlar üzerine kurulur. Onun bu gemiyi neden finanse ettiğini sanıyorsun?
    -> fiona_basamak_3
* [  Arthur bu gece biraz fazla gergin değil mi?]
    Her zaman öyledir. Elindeki bastonu sadece yürümek için kullanmıyor, emin ol. Birinin diz kapağına çarpmak için her an hazır.
    -> fiona_basamak_3

=== fiona_basamak_3 ===
* [  Şu köşedeki adam neden sürekli seni izliyor?]
    O mu? Bazı sessizlikler en güvenli limandır. O, bu gemideki en dürüst kalp...
    -> fiona_basamak_4
* [  O adamla işaretleşiyor gibisin?]
    Bana Lucia'nın piyanosuna fazla yaklaşmamamı söyledi. Bazı notaların içinde zehir varmış, öyle diyor.
    -> fiona_basamak_4

=== fiona_basamak_4 ===
* [  Sen her şeyi biliyor gibisin.]
    Bilmek değil, birleştirmek tatlım. Mesela Ada W’nin o gümüş saatinin aslında kime ait olduğunu biliyorum. Ama şşşt, bu bir sır.
    -> fiona_basamak_6
* [  Bir şey gördün, değil mi?]
    Belki... Bastian ve Valeria'nın arka odada ne fısıldaştığını duysan, sen de benim gibi bu şampanyayı yutmakta zorlanırdın.
    -> fiona_basamak_5

=== fiona_basamak_5 ===
// Fiona tedirgin olur ve konuşmayı bitirir.
* [  Gördüklerin bu geceyi değiştirebilir mi?]
    Değiştirmek mi? Ben sadece izleyiciyim tatlım. Ama bu gemide fazla meraklı izleyicilerin başına neler geldiğini bilsen, arkana bakmadan kaçardın. Üzgünüm, boğazım kurudu.
    -> END
* [  Valeria'yı bu yüzden mi bu kadar dikkatli süzüyorsun?]
    (Kadehini sıkıca kavrar) Çok fazla soru soruyorsun yabancı. Bazı gerçekler paylaşılamayacak kadar ağırdır. Şimdilik bu kadar yeter, bol şans.
    -> END

=== fiona_basamak_6 ===
// Kolye ve Trajik İroni
+ [  Bu gece senin için neden bu kadar önemli?]
    Çünkü bu gece, kimin maskesinin düşeceğini görmek için en önden bilet aldım. Belki de sahneden inme sırası bendedir, kim bilir?
    -> fiona_basamak_6_devam
+ [  Herkesten şüpheleniyor gibisin.]
    Şüphe, bu gemideki tek gerçek duygudur tatlım. Bak, ışıklar titremeye başladı bile... Sahne başlıyor.
    -> fiona_basamak_6_devam
+ [  Sence kolye doğru ellerde mi?]
    Pek sanmıyorum.
    -> fiona_basamak_6_devam

= fiona_basamak_6_devam
// 
+ [  Teşekkürler, Fiona.]
    Dikkatli ol tatlım, bu sular göründüğünden daha derin. 
    -> END
    
=== fiona_fallback ===
Tanıştığımıza sevindim.
-> END
    