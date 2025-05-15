pipeline {
    agent any

    environment {
        SOLUTION_FOLDER = 'ApiAutomationTests'
    }

    triggers {
        pollSCM('* * * * *')
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/ShivamNashTech1869/ApiAutomationTests.git', branch: 'main'
            }
        }

        stage('Restore Dependencies') {
            steps {
                dir("${env.SOLUTION_FOLDER}") {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build Project') {
            steps {
                dir("${env.SOLUTION_FOLDER}") {
                    sh 'dotnet build --no-restore'
                }
            }
        }

        stage('Run Tests') {
            steps {
                dir("${env.SOLUTION_FOLDER}") {
                    sh 'dotnet test --no-build --logger:"console;verbosity=normal"'
                }
            }
        }
    }

    post {
        always {
            echo 'Cleaning up...'
        }
        success {
            echo 'Pipeline executed successfully!'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}

