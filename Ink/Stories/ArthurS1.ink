// --- ARTHUR KANE: GÜVENLİK VE STRATEJİ ---

// Değişkeni en üstte tanımlıyoruz ki tüm arthur_basamaklar buna erişebilsin.
VAR ipucu_alindi = false

-> arthur_basamak_1

=== arthur_basamak_1 ===
İnsan seslerini hatırlamaya çalışırım. Sizinki tanıdık değil.

*  [Ben de tam size aynısını söyleyecektim.]
    ~ DiscoverNPC() 
    Demek iki yabancıyız. Bana Arthur diyebilirsiniz.
    -> arthur_basamak_2
*  [İlk kez bir baloya katılıyorum.]
    ~ DiscoverNPC() 
    İlk balonuz için oldukça güzel bir gemi seçmişsiniz. Bana Arthur diyebilirsiniz.
    -> arthur_basamak_2

=== arthur_basamak_2 ===
*  Kalabalık seni rahatsız etmiyor mu?
    Kalabalık… Bilgi demektir. Gürültünün içinde fısıltıları duymayı öğrenmelisin.
    -> arthur_basamak_3
*  İnsanları izliyorsun.
    ~ ipucu_alindi = true
    Alışkanlık diyelim. Kimin kiminle fısıldaştığını bilmek, hayatta tutar.
    -> arthur_basamak_3
*  Hiçbir detayı kaçırmıyor gibisin.
    Detaylar her zaman oradadır. Onları görmek için sadece gözlerini açman yeterli.
    -> arthur_basamak_3

=== arthur_basamak_3 ===

{ipucu_alindi:
    +  [O zaman buralarda size tanıdık gelen birileri olmalı.]
        Henüz değil. Ama sürekli kapıya bakmamın bir sebebi var; geç kalanlar genellikle en ilginç olanlardır.
        -> arthur_basamak_3
}

+  Sergilenecek kolye için alınan önlemler abartılı değil mi?
    Kolyenin değerini duysan az bile dersin.
    -> arthur_basamak_3

*  [Sizi tanıdığıma sevindim, görüşmek üzere bayım.]
    İyi eğlenceler.
    -> END