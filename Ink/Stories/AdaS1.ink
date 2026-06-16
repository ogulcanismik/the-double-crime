// --- MACERA BAŞLIYOR: ADA W ---
-> ada_basamak_1

=== ada_basamak_1 ===
Merhabalar, umarım geceniz iyi geçiyordur.

*  [Bu ortam size çok uygun görünüyor.]
    Eskiden daha uygundu. Şimdilerde pek tadı kalmadı.
    -> ada_basamak_2_iltifat
* [Buralara yabancı gibi duruyorsunuz.]
    Ömrüm bunun gibi balolarda geçti. Sesiniz de pek tanıdık gelmiyor.
    -> ada_basamak_2_gozlem

=== ada_basamak_2_iltifat ===
* Eskiden buralar nasıldı?
    Böylesine hırslı kimseler yoktu. Hepsinin derdi para.
    -> ada_basamak_3
* Sizin zarafetiniz aynı kalmış.
    Çok kibar bir genç adamsınız. Teşekkür ederim.
    ~ ModifyOpinion(30)
    -> ada_basamak_2_gozlem

=== ada_basamak_2_gozlem ===
*  [İsmim Jeff]
    Bana Ada diyebilirsiniz.
    ~ DiscoverNPC()
    -> ada_basamak_3
*  [İsmim John (Yalan Söyle)]
    Bana Ada diyebilirsiniz.
    ~ DiscoverNPC()
    ->ada_basamak_3
*  [Bu katıldığım ilk balo]
    Umarım eğlenirsiniz yabancı.  
    -> ada_basamak_2_gozlem

=== ada_basamak_3 ===
*  Kolyeyi nasıl buluyorsunuz?
    Taşın kesimi mükemmel, ancak sahibi kolyeyi gölgede bırakıyor.
    -> ada_basamak_4
*  Bu geceki "ana parça" hakkında ne düşünüyorsunuz?
    Bir tasarım harikası. Sahibi de bir o kadar güzel.
    -> ada_basamak_4

=== ada_basamak_4 ===
+  Saatiniz gerçekten büyüleyici.
    Zamanın satılık olmadığı günlerden bir hatıra… Ona fazla yaklaşma.
    -> ada_basamak_4
+  Bu gece her şey değişebilir, hazırlıklı olun.
    Ben sadece izlerim.
    -> ada_basamak_4
*  İyi eğlenceler.
    İyi eğlenceler hayatım.
    -> END