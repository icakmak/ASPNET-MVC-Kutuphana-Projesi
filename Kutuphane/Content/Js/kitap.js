$(document).on("click", "#dEkle", function () {
    var secilenKategori = $("#kategoriler").val();
    var secilenId = $("#kategoriler option:selected").attr("data-id");
    $("#eklenenKategoriler").append('<div id="' + secilenId + '" class="col-md-1 bg-primary kategoriSil" style="margin:5px;" >' + secilenKategori + "</div>");
    $("#kategoriler option:selected").remove();
});

$(document).on("click", ".kategoriSil", function () {
    var id = $(this).attr("id");
    var kategoriAd = $(this).html();
    $("#kategoriler").append('<option data-id="' + id + '">' + kategoriAd + '</option>');
    $(this).remove();
});

$(document).on("click", "#kitapKaydet", function () {
    var degerler = {
        "kitapAdi": $("#kitapAdi").val(),
        "kitapSira": $("#kitapSira").val(),
        "kitapAdet": $("#kitapAdet").val(),
        "yazar": $("#yazar option:selected").attr("data-id"),
        "kategoriler":[]
    }
    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });
    $.ajax({
        type: 'POST',
        url: '/Kitap/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Kitap Eklendi',
                    text: 'İşlem Başarı ile Gerçekleştirildi!!'
                });
            }
            
        },
        error: function(){
            Swal.fire({
                type: 'error',
                title: 'Kitap Eklenemedi',
                text:'Bir Sorun ile Karşılaşıldı!'
            });
        }
    });
});