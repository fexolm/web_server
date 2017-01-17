$(document).ready(function () {
    var photos = ["https://pp.vk.me/c630417/v630417499/4096b/jXphjabjaiw.jpg",
        "https://pp.vk.me/c625225/v625225499/44790/39oS4yu9bqM.jpg",
        "https://pp.vk.me/c622327/v622327499/3a9c9/2cmZesUxZh4.jpg",
        "https://pp.vk.me/c637423/v637423499/7f20/GCwVHmArL4g.jpg"
    ];
    var i = 1;
    $("#image_selecror").click(function () {
        $("#image_selecror").prop("src", photos[i]);
        i = (i + 1) % 4;
    });
});