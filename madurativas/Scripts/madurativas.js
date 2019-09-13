$(function () {

    // #region Question 1

    var $dt1_quest1 = $("#dt1_quest_1");
    var $dt1_quest2 = $("#dt1_quest_2");
    var $dt1_quest3 = $("#dt1_quest_3");
    var $dt1_quest4 = $("#dt1_quest_4");
    var $dt1_quest5 = $("#dt1_quest_5");
    var $dt1_quest6 = $("#dt1_quest_6");
    var $dt1_quest7 = $("#dt1_quest_7");
    var $dt1_quest8 = $("#dt1_quest_8");

    var $dt1_quest1b = $("#dt1_quest1b");
    var $dt1_lblEjPasa = $("#ejPasa");
    var $dt1_lblEjFalla = $("#ejFalla");
    var $dt1_lblResultado = $("#lblResultado");


    $("#FrmQuest1 > div.bootstrap-switch-container > span").click(function () {
        $dt1_lblEjPasa.show();
        $(".cuestionario").show();

        if ($dt1_quest1.is(":checked")) {
            $dt1_quest1b.empty();
            $dt1_quest1b.append("Por favor, deme un ejemplo de cómo su hijo o hija respondería si Ud. señala algo (si el padre/madre no da un ejemplo de PASA o FALLA de los que están debajo, pregunte cada uno individualmente).");

        } else {
            $dt1_quest1b.empty();
            $dt1_quest1b.append("Si Ud. señala algo, ¿qué hace su hijo o hija habitualmente?");

        }


        if (cuentaPasa() < 7) {
            $dt1_lblResultado.empty();
            if (cuentaFallas() < 7) {

                $dt1_lblResultado.append("Resultado de la prueba:*");
                $("#observacion").show();
            } else {
                $dt1_lblResultado.append("Resultado de la prueba:");
                $("#observacion").hide();
            }
        } else {
            $dt1_lblResultado.empty();
            $dt1_lblResultado.append("Resultado de la prueba:");
            $("#observacion").hide();
        }

        function cuentaFallas() {
            var nFallas = 0;

            if (!$dt1_quest2.is(':checked')) nFallas++;
            if (!$dt1_quest3.is(':checked')) nFallas++;
            if (!$dt1_quest4.is(':checked')) nFallas++;
            if (!$dt1_quest5.is(':checked')) nFallas++;

            if ($dt1_quest6.is(':checked')) nFallas++;
            if ($dt1_quest7.is(':checked')) nFallas++;
            if ($dt1_quest8.is(':checked')) nFallas++;

            return nFallas;

        }

        function cuentaPasa() {
            var nPasa = 0;

            if ($dt1_quest2.is(":checked")) nPasa++;
            if ($dt1_quest3.is(":checked")) nPasa++;
            if ($dt1_quest4.is(":checked")) nPasa++;
            if ($dt1_quest5.is(":checked")) nPasa++;

            if (!$dt1_quest6.is(":checked")) nPasa++;
            if (!$dt1_quest7.is(":checked")) nPasa++;
            if (!$dt1_quest8.is(":checked")) nPasa++;

            return nPasa;

        }

    });

    $("#btndtq1Save").click(function (e) {

        e.preventDefault();

        var form = $("#FrmQuest1");

        var datos = {
            estudioId: $("#estudio_id").val(),
            quest1: $dt1_quest1.is(":checked"),
            quest2: $dt1_quest2.is(":checked"),
            quest3: $dt1_quest3.is(":checked"),
            quest4: $dt1_quest4.is(":checked"),
            quest5: $dt1_quest5.is(":checked"),
            quest6: $dt1_quest6.is(":checked"),
            quest7: $dt1_quest7.is(":checked"),
            quest8: $dt1_quest8.is(":checked")

        };

        $.ajax({
            url: form.attr("action"),
            method: form.attr("method"),
            data: datos
        });

    });

    // #endregion

    // #region Question 2

    var $dt2_quest1 = $("#dt2_quest_1");
    var $dt2_quest2 = $("#dt2_quest_2");
    var $dt2_quest3 = $("#dt2_quest_3");
    var $dt2_quest4 = $("#dt2_quest_4");

    var $dt2_lblResultado = $("#dt2lblResultado");

    function Question2Decision() {
        var nPasa = 0;
        if (!$dt2_quest1.is(":checked")) nPasa++;
        if (!$dt2_quest2.is(":checked")) nPasa++;
        //if ($dt2_quest3.is(':checked')) nPasa++;


        return nPasa;

    }

    function validaFormQuestion2() {
        if (Question2Decision() < 2) {
            $dt2_lblResultado.empty();
            $dt2_lblResultado.append("Falla");

        } else {
            $dt2_lblResultado.empty();
            $dt2_lblResultado.append("Pasa");
        }
    }

    validaFormQuestion2();

    $("form#FrmQuest2 div.bootstrap-switch-container > span").on("click", function () {
        

        validaFormQuestion2();

    });

    $("from#FrmQuest2").children("div.bootstrap-switch-container > span").click(function () {
        alert("prueba");
    });

    $("#btndtq2Save").click(function (e) {

        e.preventDefault();

        var form = $("#FrmQuest2");

        var datos = {
            estudioId: $("#estudio_id").val(),
            quest1: $dt2_quest1.is(":checked"),
            quest2: $dt2_quest2.is(":checked"),
            quest3: $dt2_quest3.is(":checked"),
            quest4: $dt2_quest4.val()
        };

        $.ajax({
            url: form.attr("action"),
            method: form.attr("method"),
            data: datos
        });

    });

    // #endregion

});

$("from#FrmQuest2").children(".bootstrap-switch-container > span").click(function () {
    alert("prueba");
});

