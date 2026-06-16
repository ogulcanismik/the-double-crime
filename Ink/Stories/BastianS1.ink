// --- BASTIAN SCWH: KOLEKSİYONER ---

VAR sir_toplama_soruldu = false

// Hikayeyi başlatıyoruz
-> bastian_basamak_1

=== bastian_basamak_1 ===
* [  Bu geceyi nasıl görüyorsun?]
    Fazla özenilmiş bir sahne. Her şey o kadar parlıyor ki, altındaki pası görmek için uzman olmak lazım.
    -> bastian_basamak_1_ozel_soru
* [  Birini bekliyor gibisiniz.]
    .....
    -> bastian_basamak_1_ozel_soru
* [  Bu ortama yabancı değil gibisiniz.]
    // Direkt seçenek 3 seçilirse verilen kısa cevap
    ...
    -> bastian_basamak_2

= bastian_basamak_1_ozel_soru
// 1 veya 2 seçildikten sonra seçenek 3 seçilirse verilen uzun cevap
* [  Bu ortama yabancı değil gibisiniz.]
    Yabancı olmak daha avantajlıdır. İnsanlar, kim olduğunu bilmedikleri birine en mahrem sırlarını fısıldamayı severler.
    -> bastian_basamak_2

=== bastian_basamak_2 ===
* [  Sahtelik bazen gerçeğinden daha değerlidir, öyle değil mi?]
    Sadece onu gerçek sanan aptallar için değerlidir. Ben gerçeğin ham ve vahşi kokusunu tercih ederim.
    -> bastian_basamak_3
* [  Sırları duymak için mi buradasınız, yoksa bir şeyler "toplamak" için mi?]
    Toplamak mı? Ben sadece hak edilen yerini bulmamış parçalara yol gösteririm yabancı.
    ~ sir_toplama_soruldu = true
    -> bastian_basamak_2
+ [  Mesela... Görmeye geldiğimiz kolye gibi mi?]
    {sir_toplama_soruldu:
        Yanlış ellerde diyelim. Benim olmayan her eşsiz parça, aslında dünyadan çalınmış bir hazinedir.
        -> bastian_basamak_3
    - else:
        Hangi kolyeden bahsettiğini anladığımdan emin değilim. Önce ne aradığını bilmelisin.
        -> bastian_basamak_2
    }

=== bastian_basamak_3 ===
* [  Bu gemideki her şey sizin için sadece bir koleksiyon parçası mı?]
    İnsanlar da dahil. Özellikle de bu gece olduğu gibi, hepsi kendi trajedisini oynamaya bu kadar hevesliyken.
    -> bastian_basamak_4
* [  Bu "sahne dekoru" sizin için fazla mı ağır geldi?]
    Ben dekorla ilgilenmem, arkasındaki mekanizmaya bakarım. Senin mekanizman ise... biraz gıcırdıyor gibi.
    -> bastian_basamak_4

=== bastian_basamak_4 ===
* [  Elinizdeki yüzük... Oldukça nadide bir parça.]
    Gözlerin keskin. Ama unutma; bir şeyi elinde tutmak için ona gerçekten sahip olman gerekir. Dokunmak, sahip olmak değildir.
    -> bastian_basamak_6
* [  Sizinle rekabet etmek zor olsa gerek.]
    Rekabet zekayı keskinleştirir. Ama bu gece rakibin ben olduğumu sanıyorsan, sahneyi yanlış okuyorsun demektir. Gözlerini o kolyeden ayıramadığını biliyorum; ama unutma, o kolyeye sadece bakmak ile ona sahip olmayı hak etmek arasında koca bir uçurum var.
    -> bastian_basamak_5

=== bastian_basamak_5 ===
* [  Belki de sandığınızdan daha büyük bir rolüm vardır.]
    Rolünü fazla ciddiye alman güzel. Ama bu gemide yanlış bir replik, seni sahneden değil, doğrudan karanlığa gönderir. Gözlerin o kolyede... Bunu sadece ben değil, diğerleri de fark edecek kadar zeki. Üzgünüm gitmem gerek.
    -> END
* [  Figüranlar bazen finali değiştirir, öyle değil mi?]
    Sadece ucuz romanlarda olur o. Gerçek dünyada figüranlar sadece dekorun bir parçasıdır. Eğer finali değiştirmek istiyorsan, önce elindeki o "emanet" duruştan kurtulmalısın. Şimdilik bu kadar yeter, bol şans.
    -> END

=== bastian_basamak_6 ===
// Seçenek 3 seçilene kadar döngü halindedir (+ işareti sayesinde)
+ [  Bu yüzüğün bir eşi daha var mı, yoksa tek mi?]
    Eşi mi? Bazı şeyler tek olmak için yaratılmıştır. Bir eşinin olması, onu sadece bir "eşya" yapar. Bu yüzük ise bir hikaye.
    -> bastian_basamak_6
+ [  Böyle bir parçayı elde etmek için nelerden vazgeçtiniz?]
    Vazgeçmek mi? Ben bir şeylerden vazgeçmem, sadece takas ederim. Bazen bir servetle…
    -> bastian_basamak_6
* [  Kolyeye de en az bu yüzük kadar değer verdiğiniz belli oluyor.]
    Değer mi? O kolye bir mücevherden fazlası, o bir meydan okuma. O parça, ancak benim ışığımda hak ettiği saygıyı görürdü. Gözlerini o kolyeden ayıramadığını biliyorum; ama unutma, o kolyeye sadece bakmak ile ona sahip olmayı hak etmek arasında koca bir uçurum var.
    -> bastian_basamak_5