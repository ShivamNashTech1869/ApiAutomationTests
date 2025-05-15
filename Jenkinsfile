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
            emailext (
                subject: "SUCCESS: Build #${env.BUILD_NUMBER} - ${env.JOB_NAME}",
                body: "Good news! The build #${env.BUILD_NUMBER} of job '${env.JOB_NAME}' succeeded.\n\nCheck it here: ${env.BUILD_URL}",
                to: "shivam.singh@nashtechglobal.com, shivamgcet221202@gmail.com"
            )
        }
        failure {
            echo 'Pipeline failed.'
            emailext (
                subject: "FAILURE: Build #${env.BUILD_NUMBER} - ${env.JOB_NAME}",
                body: "Oops! The build #${env.BUILD_NUMBER} of job '${env.JOB_NAME}' failed.\n\nPlease check the logs here: ${env.BUILD_URL}",
                to: "shivam.singh@nashtechglobal.com, shivamgcet221202@gmail.com"
            )
        }
    }
}

