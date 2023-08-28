
function ExclusaoConfirm(tarefaId, nomeTarefa) {
    $(".nomeTarefa").text(nomeTarefa);
    //$(".nomeTarefa").text(nomeTarefa);
    $(".modal").modal();

    $(".btnExcluir").on('click', function () {
        $.ajax({
            url: 'Tarefas/RemoverTarefa',
            method: 'POST',
            data: { id: tarefaId },
            success: function (data) {
                $(".modal").modal('hide');
                location.reload(true);
            }
        });
    });

    $('.btnFechar').on('click', function () {
        tarefaId = null;
        nomeTarefa = null;
        $(".modal").modal('hide');
    });
}
