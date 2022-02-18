$(document).on("click", ".yzrEkle", async function () {
    const { value: formValues } = await 
    Swal.fire({
        title: 'Yazar Ekle',
        html:
            '<input id="yzrAd" class="swal2-input">',
    })

    if (formValues) {
        var yzrAd = $("#yzrAd").val();

        $.ajax({
            type: 'Post',
            url: '/Yazar/EkleJson',
            data: { "yzrAd": yzrAd },
            dataType: 'Json',
            success: function (data) {
                var yzrId = '<td>' + data.Result.Id +'</td>';
                var yzrAd = '<td>' + data.Result.Ad + '</td>';
                var gncBtn = '<td><button class="guncelle btn btn-custom" value="' + data.Result.Id + '">Güncelle</button></td>';
                var silBtn = '<td><button class="sil btn btn-danger" value="' + data.Result.Id + '">sil</button></td>';

                
                var kitapSayisi = '<td>0</td>';
                $("#example tbody").prepend(
                    "<tr>"  + yzrAd + kitapSayisi + gncBtn + silBtn+'</tr>'
                );
                Swal.fire({
                    type: 'success',
                    title: 'Yazar Eklendi',
                    text: 'işlem Başarı ile Gerçekleşti!'
                });
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Yazar Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }
});

$(document).on("click", ".guncelle", async function () {
    var yzrId = $(this).val();
    var yzrAdTd = $("#td_" + yzrId).text();
    console.log(yzrAdTd)
    const { value: formValues } = await Swal.fire({
        title: 'Yazar Güncelle',
        html:
            '<input id="yzrAd" class="swal2-input" value="' + yzrAdTd + '">',
    });

    if (formValues) {
        var yzrAd = $("#yzrAd").val();

        $.ajax({
            type: 'Post',
            url: '/Yazar/GuncelleJson',
            data: { "yzrId": yzrId, "yzrAd": yzrAd },
            dataType: 'Json',
            success: function (data) {
                if (data == 1) {
                    $("#td_" + yzrId).text(yzrAd);
                    Swal.fire({
                        type: 'success',
                        title: 'Yazar Güncellendi',
                        text: 'işlem Başarı ile Gerçekleşti!'
                    });
                } else {

                }
                
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Yazar Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }

});

$(document).on("click", ".sil", async function () {
    var yzrId = $(this).val();
    var yzrAdTd = $("#td_" + yzrId).text();
    var tr = $(this).parent("td").parent("tr");
    const { value: formValues } = await Swal.fire({
        title: 'Yazar Silme',
        html:
            '<input id="yzrAd" class="swal2-input" value="' + yzrAdTd + '">',
    });
    if (formValues) {
        tr.remove();

        $.ajax({
            type: 'Post',
            url: '/Yazar/SilJson',
            data: { "yzrId": yzrId },
            dataType: 'Json',
            success: function (data) {
                if (data == 1) {
                    
                    Swal.fire({
                        type: 'success',
                        title: 'Yazar Silindi',
                        text: 'işlem Başarı ile Gerçekleşti!'
                    });
                } else {

                }

            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Yazar Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }
});