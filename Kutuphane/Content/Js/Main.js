$(document).on("click", ".ktgEkle", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Ekle',
        html:
            '<input id="ktgAd" class="swal2-input">',
    })

    if (formValues) {
        var ktgAd = $("#ktgAd").val();
        
        $.ajax({
            type: 'Post',
            url: '/Kategori/EkleJson',
            data: { "ktgAd": ktgAd },
            dataType: 'Json',
            success: function (data) {
                var ktgId = '<td>' + data.Result.Id +'</td>';
                var ktgAd = '<td>' + data.Result.Ad + '</td>';
                var gncBtn = '<td><button class="guncelle btn btn-custom" value="' + data.Result.Id + '">Güncelle</button></td>';
                var silBtn = '<td><button class="sil btn btn-danger" value="' + data.Result.Id + '">sil</button></td>';

                
                var kitapSayisi = '<td>0</td>';
                $("#example tbody").prepend(
                    "<tr>"  + ktgAd + kitapSayisi + gncBtn + silBtn+'</tr>'
                );
                Swal.fire({
                    type: 'success',
                    title: 'Kategori Eklendi',
                    text: 'işlem Başarı ile Gerçekleşti!'
                });
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }
});

$(document).on("click", ".guncelle", async function () {
    var ktgId = $(this).val();
    var ktgAdTd = $("#td_" + ktgId).text();
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Güncelle',
        html:
            '<input id="ktgAd" class="swal2-input" value=' + ktgAdTd + '>',
    });

    if (formValues) {
        var ktgAd = $("#ktgAd").val();

        $.ajax({
            type: 'Post',
            url: '/Kategori/GuncelleJson',
            data: { "ktgId": ktgId, "ktgAd": ktgAd },
            dataType: 'Json',
            success: function (data) {
                if (data == 1) {
                    $("#td_" + ktgId).text(ktgAd);
                    Swal.fire({
                        type: 'success',
                        title: 'Kategori Güncellendi',
                        text: 'işlem Başarı ile Gerçekleşti!'
                    });
                } else {

                }
                
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }

});

$(document).on("click", ".sil", async function () {
    var ktgId = $(this).val();
    var ktgAdTd = $("#td_" + ktgId).text();
    var tr = $(this).parent("td").parent("tr");
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Silme',
        html:
            '<input id="ktgAd" class="swal2-input" value=' + ktgAdTd + '>',
    });
    if (formValues) {
        tr.remove();

        $.ajax({
            type: 'Post',
            url: '/Kategori/SilJson',
            data: { "ktgId": ktgId },
            dataType: 'Json',
            success: function (data) {
                if (data == 1) {
                    
                    Swal.fire({
                        type: 'success',
                        title: 'Kategori Silindi',
                        text: 'işlem Başarı ile Gerçekleşti!'
                    });
                } else {

                }

            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    text: 'Bir Sorun İle Karşılaşıldı!'
                });
            }

        });
    }
});