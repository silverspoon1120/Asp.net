﻿(function () {
    var controllerId = 'app.views.questions.detail';
    angular.module('app').controller(controllerId, [
        '$state', 'abp.services.app.question',
        function ($state, questionService) {
            var vm = this;

            vm.question = null;
            vm.answerText = '';

            vm.voteUp = function () {
                questionService.voteUp({
                    id: vm.question.id
                }).success(function (data) {
                    vm.question.voteCount = data.voteCount;
                    abp.notify.info("Saved your vote. Thanks.");
                });
            };

            vm.voteDown = function () {
                questionService.voteDown({
                    id: vm.question.id
                }).success(function (data) {
                    vm.question.voteCount = data.voteCount;
                    abp.notify.info("Saved your vote. Thanks.");
                });
            };

            vm.submitAnswer = function() {
                questionService.submitAnswer({
                    questionId: vm.question.id,
                    text: vm.answerText
                }).success(function (data) {
                    vm.question.answers.push(data.answer);
                    vm.answerText = '';
                });
            };

            //Loading question
            abp.ui.setBusy(
                null,
                questionService.getQuestion({
                    id: $state.params.id,
                    incrementViewCount: true
                }).success(function(data) {
                    vm.question = data.question;

                    //Moving accepted answer to top
                    var acceptedAnswerIndex = -1;
                    for (var i = 0; i < vm.question.answers.length; i++) {
                        if (vm.question.answers[i].isAccepted) {
                            acceptedAnswerIndex = i;
                            break;
                        }
                    }

                    if (acceptedAnswerIndex > 0) {
                        var acceptedAnswer = vm.question.answers[acceptedAnswerIndex];
                        vm.question.answers.splice(acceptedAnswerIndex, 1);
                        vm.question.answers.unshift(acceptedAnswer);
                    }
                })
            );
        }
    ]);
})();